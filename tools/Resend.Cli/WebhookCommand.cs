using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli;

/// <summary />
[Command( "webhook", Description = "Webhook management" )]
[Subcommand( typeof( Webhook.WebhookCreateCommand ))]
[Subcommand( typeof( Webhook.WebhookListCommand ))]
[Subcommand( typeof( Webhook.WebhookDeleteCommand ) )]
public class WebhookCommand
{
    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
