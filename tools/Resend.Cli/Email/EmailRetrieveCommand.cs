using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Email;

/// <summary />
[Command( "get" )]
public class EmailRetrieveCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "EMAIL GET" );

        return 0;
    }
}
