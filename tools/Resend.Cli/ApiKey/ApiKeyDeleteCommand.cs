using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.ApiKey;

/// <summary />
[Command( "delete" )]
public class ApiKeyDeleteCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "API key identifier" )]
    [Required]
    public Guid KeyId { get; set; }


    /// <summary />
    public ApiKeyDeleteCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.ApiKeyDelete( this.KeyId );

        return 0;
    }
}
