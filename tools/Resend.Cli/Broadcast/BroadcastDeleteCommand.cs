using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Broadcast;

/// <summary />
[Command( "delete", Description = "Delete a broadcast" )]
public class BroadcastDeleteCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Broadcast identifier" )]
    [Required]
    public Guid? BroadcastId { get; set; }


    /// <summary />
    public BroadcastDeleteCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.BroadcastDeleteAsync( this.BroadcastId!.Value );

        return 0;
    }
}
