using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Audience;

/// <summary />
[Command( "add", Description = "Create an Audience" )]
public class AudienceAddCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Audience name" )]
    [Required]
    public string Name { get; set; } = default!;


    /// <summary />
    public AudienceAddCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.AudienceAddAsync( this.Name );
        var audience = res.Content;


        /*
         * 
         */
        Console.WriteLine( audience.Id );
        Console.WriteLine( audience.Name );

        return 0;
    }
}
