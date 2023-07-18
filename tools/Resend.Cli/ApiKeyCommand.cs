using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli;

/// <summary />
[Command( "api-key" )]
[Subcommand( typeof( ApiKey.ApiKeyCreateCommand ))]
[Subcommand( typeof( ApiKey.ApiKeyListCommand ))]
[Subcommand( typeof( ApiKey.ApiKeyRemoveCommand ) )]
public class ApiKeyCommand
{
    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
