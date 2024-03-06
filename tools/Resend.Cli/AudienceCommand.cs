using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli;

/// <summary />
[Command( "audience", Description = "Audience management" )]
[Subcommand( typeof( Audience.AudienceAddCommand ) )]
[Subcommand( typeof( Audience.AudienceRetrieveCommand ))]
[Subcommand( typeof( Audience.AudienceDeleteCommand ) )]
[Subcommand( typeof( Audience.AudienceListCommand ) )]
public class AudienceCommand
{
    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
