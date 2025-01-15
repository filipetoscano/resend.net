using McMaster.Extensions.CommandLineUtils;
using Resend.Webhooks;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Resend.Cli.Webhook;

/// <summary />
[Command( "post", Description = "Post a webhook event onto a Webhook sink" )]
public class WebhookPostCommand
{
    /// <summary />
    [Option( "-i|--input", CommandOptionType.SingleValue, Description = "" )]
    [FileExists]
    [Required]
    public string? EventData { get; set; }

    /// <summary />
    [Option( "-u|--url", CommandOptionType.SingleValue, Description = "Webhook URL" )]
    [Required]
    public string? WebhookUrl { get; set; }

    /// <summary />
    [Option( "-s|--secret", CommandOptionType.SingleValue, Description = "" )]
    [Required]
    public string? SigningSecret { get; set; } = Environment.GetEnvironmentVariable( "RESEND_WEBHOOK_SECRET" );



    /// <summary />
    public WebhookPostCommand()
    {
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * 
         */
        var messageId = Guid.NewGuid().ToString();
        var now = DateTimeOffset.Now;

        var json = File.ReadAllText( this.EventData! );


        /*
         * 
         */
        var whs = new WebhookSigner( this.SigningSecret! );
        var signature = whs.Sign( messageId, now, json );


        /*
         * 
         */
        Console.WriteLine( "MessageId={0}", messageId );
        Console.WriteLine( "Timestamp={0}", now.ToUnixTimeSeconds() );
        Console.WriteLine( "Signature={0}", signature );


        /*
         * 
         */
        var client = new HttpClient();

        var req = new HttpRequestMessage( HttpMethod.Post, this.WebhookUrl );
        req.Headers.Add( "svix-id", messageId );
        req.Headers.Add( "svix-timestamp", now.ToUnixTimeSeconds().ToString() );
        req.Headers.Add( "svix-signature", signature );

        req.Content = new StringContent( json, Encoding.UTF8, "application/json" );

        var resp = await client.SendAsync( req );

        Console.WriteLine( "StatusCode={0} {1}", (int) resp.StatusCode, resp.StatusCode );


        /*
         * 
         */
        return 0;
    }
}