using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Contact;

/// <summary />
[Command( "list", Description = "Show all contacts from an audience." )]
public class ContactListCommand
{
    private readonly IResend _resend;

    /// <summary />
    [Argument( 0, Description = "The Audience identifier" )]
    [Required]
    public Guid AudienceId { get; set; }

    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public ContactListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.ContactListAsync( this.AudienceId );
        var contacts = res.Content;

        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( contacts, jso );

            Console.WriteLine( json );
        }
        else
        {
            var table = new Table();
            table.Border = TableBorder.SimpleHeavy;
            table.AddColumn( "Contact Id" );
            table.AddColumn( "Email" );
            table.AddColumn( "First Name" );
            table.AddColumn( "Last Name" );
            table.AddColumn( "Created" );
            table.AddColumn( "Unsubscription" );

            foreach ( var c in contacts )
            {
                #pragma warning disable CS8604 // Possible null reference argument.
                table.AddRow(
                   new Markup( c.Id.ToString() ),
                   new Markup( c.Email ),
                   new Markup( c.FirstName != null ? c.FirstName : "" ),
                   new Markup( c.LastName != null ? c.LastName : "" ),
                   new Markup( c.Created.ToShortDateString() ),
                   new Markup( text: c.Unsubscribed == null ? "" : c.Unsubscribed.ToString() )
                   );
                #pragma warning restore CS8604 // Possible null reference argument.
            }

            AnsiConsole.Write( table );
        }

        return 0;
    }
}
