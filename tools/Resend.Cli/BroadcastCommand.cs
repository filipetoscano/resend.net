using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli;

/// <summary />
[Command( "broadcast", Description = "Broadcadt management" )]
[Subcommand( typeof( Broadcast.BroadcastAddCommand ))]
[Subcommand( typeof( Broadcast.BroadcastDeleteCommand ) )]
[Subcommand( typeof( Broadcast.BroadcastListCommand ) )]
[Subcommand( typeof( Broadcast.BroadcastRetrieveCommand ))]
[Subcommand( typeof( Broadcast.BroadcastScheduleCommand ) )]
[Subcommand( typeof( Broadcast.BroadcastSendCommand ) )]
public class BroadcastCommand
{
    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
