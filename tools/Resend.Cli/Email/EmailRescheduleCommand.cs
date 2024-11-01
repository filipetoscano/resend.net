using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Email;

/// <summary />
[Command( "reschedule", Description = "Cancels a scheduled email" )]
public class EmailRescheduleCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Email identifier" )]
    public Guid EmailId { get; set; }

    /// <summary />
    [Argument( 1, Description = "Reschedule for" )]
    public DateTime RescheduleFor { get; set; }


    /// <summary />
    public EmailRescheduleCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.EmailRescheduleAsync( this.EmailId, this.RescheduleFor );

        return 0;
    }
}
