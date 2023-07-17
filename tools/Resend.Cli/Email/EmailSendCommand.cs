using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Email;

/// <summary />
[Command( "send" )]
public class EmailSendCommand
{
    /// <summary />
    public int OnExecute()
    {
        Console.WriteLine( "SEND EMAIL" );

        return 0;
    }
}
