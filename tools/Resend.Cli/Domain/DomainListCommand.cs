using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "list" )]
public class DomainListCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "DOMAIN LIST" );

        return 0;
    }
}
