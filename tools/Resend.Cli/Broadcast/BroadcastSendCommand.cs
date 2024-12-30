using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Broadcast;

/// <summary />
[Command( "send", Description = "Send a broadcast" )]
public class BroadcastSendCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Broadcast identifier" )]
    [Required]
    public Guid? BroadcastId { get; set; }


    /// <summary />
    public BroadcastSendCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.BroadcastSendAsync( this.BroadcastId!.Value );

        return 0;
    }
}
