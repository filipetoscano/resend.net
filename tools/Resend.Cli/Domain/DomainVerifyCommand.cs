using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "verify" )]
public class DomainVerifyCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "DOMAIN VERIFY" );

        return 0;
    }
}
