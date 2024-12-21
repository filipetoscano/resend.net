using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Svix.Exceptions;
using System.Net;
using System.Text.Json;

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
    public ActionResult<Webhook> Validate( IHeaderDictionary header, string payload )
    {
        /*
         * TODO:
         */
        var h = new WebHeaderCollection();
        h.Add( "svix-id", "" );
        h.Add( "svix-timestamp", "" );
        h.Add( "svix-signature", "" );


        /*
         * 
         */
        if ( IsValid( h, payload ) == false )
            return new BadRequestResult();


        /*
         * 
         */
        var obj = JsonSerializer.Deserialize<Webhook>( payload );

        if ( obj == null )
            return new BadRequestResult();

        return obj;
    }


    /// <summary />
    public bool IsValid( WebHeaderCollection headers, string payload )
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
