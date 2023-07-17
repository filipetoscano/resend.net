using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "get" )]
public class DomainRetrieveCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "DOMAIN GET" );

        return 0;
    }
}
