using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Contact;

/// <summary />
[Command( "patch", Description = "Update a contact" )]
public class ContactUpdateCommand
{
    private readonly IResend _resend;

    /// <summary />
    [Argument( 0, Description = "The Audience Id." )]
    [Required]
    public Guid AudienceId { get; set; }

    /// <summary />
    [Argument( 1, Description = "The Contact identifier" )]
    public Guid ContactId { get; set; }

    /// <summary />
    [Argument( 2, Description = "The email address of the contact." )]
    [Required]
    public string Email { get; set; } = string.Empty;

    /// <summary />
    [Argument( 3, Description = "The first name of contact." )]
    public string? FirstName { get; set; } = default!;

    /// <summary />
    [Argument( 4, Description = "The last name of contact." )]
    public string? LastName { get; set; } = default!;

    /// <summary />
    [Argument( 5, Description = "The subscription status." )]
    public bool? Unsubscription { get; set; } = default!;


    /// <summary />
    public ContactUpdateCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.ContactUpdateAsync( this.AudienceId, this.ContactId, this.Email, this.FirstName, this.LastName, this.Unsubscription );
        var contact = res.Content;


        /*
         * 
         */
        Console.WriteLine( contact.Id );

        return 0;
    }
}
