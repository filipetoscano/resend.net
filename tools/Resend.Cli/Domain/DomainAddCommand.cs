using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "add" )]
public class DomainAddCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "DOMAIN ADD" );

        return 0;
    }
}
