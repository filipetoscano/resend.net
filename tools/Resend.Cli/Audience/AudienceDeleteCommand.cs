using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Audience;

/// <summary />
[Command( "delete", Description = "Deletes an audience" )]
public class AudienceDeleteCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Audience identifier" )]
    [Required]
    public Guid AudienceId { get; set; }


    /// <summary />
    public AudienceDeleteCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.AudienceDeleteAsync( this.AudienceId );

        return 0;
    }
}
