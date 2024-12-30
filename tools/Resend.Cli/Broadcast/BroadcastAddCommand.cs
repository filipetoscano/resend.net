using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Broadcast;

/// <summary />
[Command( "add", Description = "Create a broadcast" )]
public class BroadcastAddCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 1, Description = "Broadcast data" )]
    [FileExists]
    [Required]
    public string? Filename { get; set; }


    /// <summary />
    public BroadcastAddCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.Filename! );
        var data = JsonSerializer.Deserialize<BroadcastData>( json );


        /*
         * 
         */
        var res = await _resend.BroadcastAddAsync( data! );
        var id = res.Content;


        /*
         * 
         */
        Console.WriteLine( id );

        return 0;
    }
}
