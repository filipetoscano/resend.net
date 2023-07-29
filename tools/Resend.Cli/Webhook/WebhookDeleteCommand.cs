using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Webhook;

/// <summary />
[Command( "delete" )]
public class WebhookDeleteCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "API key identifier" )]
    [Required]
    public Guid WebhookId { get; set; }


    /// <summary />
    public WebhookDeleteCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await Task.Delay( 100 );

        // await _resend.WebhookDelete( this.KeyId );

        return 0;
    }
}
