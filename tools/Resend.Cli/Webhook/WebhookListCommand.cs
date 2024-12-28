using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace Resend.Cli.Webhook;

/// <summary />
[Command( "list" )]
public class WebhookListCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public WebhookListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        //var res = await _resend.WebhookListAsync();
        await Task.Delay( 0 );
        var hooks = new List<Resend.Webhook>();


        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( hooks, jso );

            Console.WriteLine( json );
        }
        else
        {
            var table = new Table();
            table.Border = TableBorder.SimpleHeavy;
            table.AddColumn( "Webhook Id" );
            table.AddColumn( "Endpoint URL" );
            table.AddColumn( "Events" );
            table.AddColumn( "Created" );

            foreach ( var d in hooks )
            {
                table.AddRow(
                    new Markup( d.Id.ToString() ),
                    new Markup( d.EndpointUrl ),
                    new Markup( string.Join( ",", d.Events ) ),
                    new Markup( d.MomentCreated.ToString() )
                );
            }

            AnsiConsole.Write( table );
        }

        return 0;
    }
}
