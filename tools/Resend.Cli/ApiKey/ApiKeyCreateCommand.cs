using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.ApiKey;

/// <summary />
[Command( "create" )]
public class ApiKeyCreateCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "APIKEY CREATE" );

        return 0;
    }
}
