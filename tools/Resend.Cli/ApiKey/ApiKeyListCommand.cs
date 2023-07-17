using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.ApiKey;

/// <summary />
[Command( "list" )]
public class ApiKeyListCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "APIKEY LIST" );

        return 0;
    }
}
