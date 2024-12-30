using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Broadcast;

/// <summary />
[Command( "get", Description = "Retrieves the broadcast" )]
public class BroadcastRetrieveCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Broadcast identifier" )]
    [Required]
    public Guid? BroadcastId { get; set; }


    /// <summary />
    public BroadcastRetrieveCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.BroadcastRetrieveAsync( this.BroadcastId!.Value );
        var value = res.Content;


        /*
         * 
         */
        var jso = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        var json = JsonSerializer.Serialize( value, jso );
        Console.WriteLine( json );

        return 0;
    }
}
