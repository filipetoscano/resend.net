using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "verify", Description = "Inititates domain verification, where Resend will inspect DNS records" )]
public class DomainVerifyCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Domain identifier" )]
    [Required]
    public Guid DomainId { get; set; }


    /// <summary />
    public DomainVerifyCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.DomainVerifyAsync( this.DomainId );

        return 0;
    }
}
