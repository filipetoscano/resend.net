using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli;

/// <summary />
[Command( "resend" )]
[Subcommand( typeof( ApiKeyCommand ) )]
[Subcommand( typeof( DomainCommand ) )]
[Subcommand( typeof( EmailCommand ) )]
public class Program
{
    /// <summary />
    public static int Main( string[] args )
    {
        try
        {
            return CommandLineApplication.Execute<Program>( args );
        }
        catch
        {
            return 2;
        }
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
