using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Svix.Exceptions;
using System.Net;
using System.Text;

namespace Resend.Webhooks;

/// <summary />
public class WebhookValidator
{
    private readonly WebhookValidatorOptions _options;


    /// <summary />
    public WebhookValidator( IOptions<WebhookValidatorOptions> options )
    {
        _options = options.Value;
    }


    /// <summary />
    public WebhookValidation Validate( HttpRequest request )
    {
        var s = new WebhookValidation();
        s.IsValid = false;


        /*
         * 
         */
        if ( request.Headers.ContainsKey( "svix-id" ) == false )
        {
            s.Exception = new WebhookException( "RWH101", "Missing required header 'svix-id'" );

            return s;
        }

        if ( request.Headers.ContainsKey( "svix-timestamp" ) == false )
        {
            s.Exception = new WebhookException( "RWH102", "Missing required header 'svix-timestamp'" );

            return s;
        }

        if ( request.Headers.ContainsKey( "svix-signature" ) == false )
        {
            s.Exception = new WebhookException( "RWH103", "Missing required header 'svix-signature'" );

            return s;
        }

        if ( long.TryParse( request.Headers[ "svix-timestamp" ].ToString(), out var ts ) == false )
        {
            s.Exception = new WebhookException( "RWH104", "Invalid value 'svix-timestamp', expected long" );

            return s;
        }

        s.MessageId = request.Headers[ "svix-id" ].ToString();
        s.Timestamp = ts;
        s.Signature = request.Headers[ "svix-signature" ].ToString();


        /*
         * 
         */
        var bodyStream = request.Body;
        string payload;

        using ( var reader = new StreamReader( bodyStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: false ) )
        {
            try
            {
                bodyStream.Position = 0;
            }
            catch
            {
                s.Exception = new WebhookException( "RWH001", "Unable to reset position, is EnableBuffering on?" );

                return s;
            }

            try
            {
                payload = reader.ReadToEnd();
            }
            catch
            {
                s.Exception = new WebhookException( "RWH002", "Unable to read raw body" );

                return s;
            }
        }

        s.Payload = payload;


        /*
         * 
         */
        var h = new WebHeaderCollection
        {
            { "svix-id", s.MessageId },
            { "svix-timestamp", s.Timestamp.ToString() },
            { "svix-signature", s.Signature }
        };

        s.IsValid = IsValid( h, payload );

        if ( s.IsValid == false )
            s.Exception = new WebhookException( "RWH201", "Signature validation failed" );

        return s;
    }


    /// <summary />
    private bool IsValid( WebHeaderCollection headers, string payload )
    {
        /*
         * 
         */
        var wh = new Svix.Webhook( _options.Secret );

        try
        {
            wh.Verify( payload, headers );
        }
        catch ( WebhookVerificationException )
        {
            return false;
        }
        catch
        {
            throw;
        }

        return true;
    }
}
