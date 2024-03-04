using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Audience;

/// <summary />
[Command( "get", Description = "Retrieves the audience" )]
public class AudienceRetrieveCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Audience identifier" )]
    [Required]
    public Guid AudienceId { get; set; }

    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public AudienceRetrieveCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.AudienceRetrieveAsync( this.AudienceId );
        var audience = res.Content;


        /*
         * 
         */
        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( audience, jso );

            Console.WriteLine( json );
        }
        else
        {
            var record = new Table();
            record.Border = TableBorder.SimpleHeavy;
            record.AddColumn( "Audience Id" );
            record.AddColumn( "Name" );
            record.AddColumn( "Created" );

            record.AddRow(
                new Markup( audience.Id.ToString() ),
                new Markup( audience.Name ),
                new Markup( audience.Created.ToShortDateString() )
                );

            AnsiConsole.Write( record );
        }

        return 0;
    }
}
