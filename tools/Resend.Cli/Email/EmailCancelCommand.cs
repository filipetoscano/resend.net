using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Email;

/// <summary />
[Command( "cancel", Description = "Cancels a scheduled email" )]
public class EmailCancelCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Email identifier" )]
    public Guid EmailId { get; set; }

    /// <summary />
    public EmailCancelCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.EmailCancelAsync( this.EmailId );

        return 0;
    }
}
