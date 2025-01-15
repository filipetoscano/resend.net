using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli;

/// <summary />
[Command( "webhook", Description = "Webhook management" )]
[Subcommand( typeof( Webhook.WebhookPostCommand ) )]
public class WebhookCommand
{
    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}