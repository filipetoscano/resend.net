using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "update", Description = "Updates a domain email sending settings" )]
public class DomainUpdateCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Domain identifier" )]
    [Required]
    public Guid DomainId { get; set; } = default!;

    /// <summary />
    [Argument( 1, Description = "Domain settings" )]
    [FileExists]
    [Required]
    public string Filename { get; set; } = "";


    /// <summary />
    public DomainUpdateCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.Filename );
        var dud = JsonSerializer.Deserialize<DomainUpdateData>( json );


        /*
         * 
         */
        var res = await _resend.DomainUpdateAsync( this.DomainId, dud! );

        return 0;
    }
}
