using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "get", Description = "Retrieves the details for an email sender domain" )]
public class DomainRetrieveCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Domain identifier" )]
    [Required]
    public Guid DomainId { get; set; }

    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Emit output as JSON array" )]
    public bool InJson { get; set; }


    /// <summary />
    public DomainRetrieveCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.DomainRetrieveAsync( this.DomainId );
        var domain = res.Content;


        /*
         * 
         */
        if ( this.InJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( domain, jso );

            Console.WriteLine( json );
        }
        else
        {
            var head = new Table();
            head.Border = TableBorder.SimpleHeavy;
            head.AddColumn( "Domain Id" );
            head.AddColumn( "Name" );
            head.AddColumn( "Region" );
            head.AddColumn( "Status" );

            head.AddRow(
                new Markup( domain.Id.ToString() ),
                new Markup( domain.Name ),
                new Markup( domain.Region.ToString() ),
                new Markup( domain.Status.ToString() )
                );

            AnsiConsole.Write( head );


            if ( domain.Records != null )
            {
                var table = new Table();
                table.Border = TableBorder.SimpleHeavy;
                table.AddColumn( "Record" );
                table.AddColumn( "Name" );
                table.AddColumn( "Type" );
                table.AddColumn( "TTL" );
                table.AddColumn( "Status" );
                table.AddColumn( "Value" );

                foreach ( var d in domain.Records )
                {
                    table.AddRow(
                        new Markup( d.Record ),
                        new Markup( d.Name ),
                        new Markup( d.RecordType ),
                        new Markup( d.TimeToLive ),
                        new Markup( d.Status.ToString() ),
                        new Markup( d.Value ?? "" )
                        );
                }

                AnsiConsole.Write( table );
            }

        }

        return 0;
    }
}
