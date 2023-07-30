using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace Resend.Cli.ApiKey;

/// <summary />
[Command( "list", Description = "Lists valid API keys" )]
public class ApiKeyListCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public ApiKeyListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.ApiKeyListAsync();
        var keys = res.Content;


        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( keys, jso );

            Console.WriteLine( json );
        }
        else
        {
            var table = new Table();
            table.Border = TableBorder.SimpleHeavy;
            table.AddColumn( "Key Id" );
            table.AddColumn( "Name" );
            table.AddColumn( "Created" );

            foreach ( var d in keys )
            {
                table.AddRow(
                    new Markup( d.Id.ToString() ),
                    new Markup( d.Name ),
                    new Markup( d.MomentCreated.ToString() )
                    );
            }

            AnsiConsole.Write( table );
        }

        return 0;
    }
}
