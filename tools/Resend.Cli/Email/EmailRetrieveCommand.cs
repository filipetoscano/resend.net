using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Resend.Cli.Email;

/// <summary />
[Command( "get", Description = "Retrieves an email which was previously sent" )]
public class EmailRetrieveCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Email identifier" )]
    [Required]
    public Guid? EmailId { get; set; }

    /// <summary />
    public EmailRetrieveCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var res = await _resend.EmailRetrieveAsync( this.EmailId!.Value );
        var email = res.Content;


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
