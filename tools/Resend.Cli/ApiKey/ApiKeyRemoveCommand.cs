using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.ApiKey;

/// <summary />
[Command( "remove" )]
public class ApiKeyRemoveCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "APIKEY REMOVE" );

        return 0;
    }
}
