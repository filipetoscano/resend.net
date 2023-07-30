using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "list", Description = "Enumerates all email sender domains in account" )]
public class DomainListCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public DomainListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.DomainListAsync();
        var domains = res.Content;

        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( domains, jso );

            Console.WriteLine( json );
        }
        else
        {
            var table = new Table();
            table.Border = TableBorder.SimpleHeavy;
            table.AddColumn( "Domain Id" );
            table.AddColumn( "Name" );
            table.AddColumn( "Region" );
            table.AddColumn( "Status" );

            foreach ( var d in domains )
            {
                table.AddRow(
                    new Markup( d.Id.ToString() ),
                    new Markup( d.Name ),
                    new Markup( d.Region.ToString() ),
                    new Markup( d.Status.ToString() )
                    );
            }

            AnsiConsole.Write( table );
        }

        return 0;
    }
}
