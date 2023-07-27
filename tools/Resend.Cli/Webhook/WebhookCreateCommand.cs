using McMaster.Extensions.CommandLineUtils;
using Resend.Net;

namespace Resend.Cli.Webhook;

/// <summary />
[Command( "create" )]
public class WebhookCreateCommand
{
    private readonly IResend _resend;


    /// <summary />
    public WebhookCreateCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public Task<int> OnExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
