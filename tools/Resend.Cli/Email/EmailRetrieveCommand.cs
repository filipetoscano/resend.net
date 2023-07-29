using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace Resend.Cli.Email;

/// <summary />
[Command( "get", Description = "Retrieves an email which was previously sent" )]
public class EmailRetrieveCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "" )]
    public Guid EmailId { get; set; }

    /// <summary />
    public EmailRetrieveCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var email = await _resend.EmailRetrieveAsync( this.EmailId );


        /*
         * 
         */
        var jso = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        var json = JsonSerializer.Serialize( email, jso );
        Console.WriteLine( json );

        return 0;
    }
}
