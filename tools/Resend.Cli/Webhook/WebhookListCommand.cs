using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Webhook;

/// <summary />
[Command( "list" )]
public class WebhookListCommand
{
    private readonly IResend _resend;


    /// <summary />
    public WebhookListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await Task.Delay( 10 );

        //var keys = await _resend.WebhookListAsync();

        //foreach ( var k in keys )
        //    Console.WriteLine( "{0} {1}", k.Id, k.Name );

        return 0;
    }
}
