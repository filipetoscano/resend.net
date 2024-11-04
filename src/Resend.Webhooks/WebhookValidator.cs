using Microsoft.Extensions.Options;
using Svix.Exceptions;
using System.Net;

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
    public bool IsValid( string payload, WebHeaderCollection headers )
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
