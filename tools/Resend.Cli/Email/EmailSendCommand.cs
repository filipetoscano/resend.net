using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace Resend.Cli.Email;

/// <summary />
[Command( "send" )]
public class EmailSendCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Option( "-i|--input", CommandOptionType.SingleValue, Description = "Input JSON file" )]
    [FileExists]
    public string InputFile { get; set; } = "email.json";


    /// <summary />
    public EmailSendCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * 
         */
        var json = File.ReadAllText( this.InputFile );
        EmailMessage message = JsonSerializer.Deserialize<EmailMessage>( json )!;

        Console.WriteLine( "From = {0}", message.From.Email );
        Console.WriteLine( "  To = {0}", string.Join( ", ", message.To ) );
        Console.WriteLine( "Subj = {0}", message.Subject );
        Console.WriteLine( "Body = {0}", message.HtmlBody );


        /*
         * 
         */
        var emailId = await _resend.EmailSendAsync( message );
        Console.WriteLine( emailId );

        return 0;
    }
}
