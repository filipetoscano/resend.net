using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Contact;

/// <summary />
[Command( "delete", Description = "Delete a contact" )]
public class ContactDeleteCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "The Audience identifier" )]
    [Required]
    public Guid AudienceId { get; set; }

    /// <summary />
    [Argument( 1, Description = "The Contact identifier" )]    
    public Guid ContactId { get; set; }

    /// <summary />
    [Argument( 2, Description = "The email address" )]
    public string Email { get; set; } = string.Empty;


    /// <summary />
    public ContactDeleteCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.ContactDeleteAsync( this.AudienceId, this.ContactId, this.Email );

        return 0;
    }
}
