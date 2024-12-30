using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Broadcast;

/// <summary />
[Command( "schedule", Description = "Schedule a broadcast" )]
public class BroadcastScheduleCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Broadcast identifier" )]
    [Required]
    public Guid? BroadcastId { get; set; }

    /// <summary />
    [Argument( 1, Description = "Schedule for" )]
    [Required]
    public DateTime? ScheduleFor { get; set; }


    /// <summary />
    public BroadcastScheduleCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.BroadcastScheduleAsync( this.BroadcastId!.Value, this.ScheduleFor!.Value );

        return 0;
    }
}
