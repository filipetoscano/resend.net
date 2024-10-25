using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace Resend.Cli.Audience;

/// <summary />
[Command( "list", Description = "Enumerates all audiences" )]
public class AudienceListCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public AudienceListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.AudienceListAsync();
        var audiences = res.Content;

        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( audiences, jso );

            Console.WriteLine( json );
        }
        else
        {
            var table = new Table();
            table.Border = TableBorder.SimpleHeavy;
            table.AddColumn( "Audience Id" );
            table.AddColumn( "Name" );
            table.AddColumn( "Created" );

            foreach ( var a in audiences )
            {
                table.AddRow(
                    new Markup( a.Id.ToString() ),
                    new Markup( a.Name ),
                    new Markup( a.MomentCreated.ToShortDateString() )
                    );
            }

            AnsiConsole.Write( table );
        }

        return 0;
    }
}
