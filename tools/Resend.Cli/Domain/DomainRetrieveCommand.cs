using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "get" )]
public class DomainRetrieveCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Domain identifier" )]
    [Required]
    public Guid DomainId { get; set; }


    /// <summary />
    public DomainRetrieveCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var domain = await _resend.DomainRetrieveAsync( this.DomainId );


        /*
         * 
         */
        var jso = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        var json = JsonSerializer.Serialize( domain, jso );
        Console.WriteLine( json );

        return 0;
    }
}
