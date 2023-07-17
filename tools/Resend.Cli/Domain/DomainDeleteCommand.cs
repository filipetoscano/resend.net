using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "delete" )]
public class DomainDeleteCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "DOMAIN DELETE" );

        return 0;
    }
}
