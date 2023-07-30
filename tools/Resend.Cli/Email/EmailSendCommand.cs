using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace Resend.Cli.Email;

/// <summary />
[Command( "send", Description = "Sends an email" )]
public class EmailSendCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Option( "-i|--input", CommandOptionType.SingleValue, Description = "Input JSON file" )]
    [FileExists]
    public string InputFile { get; set; } = "email.json";

    /// <summary />
    [Option( "-v|--verbose", CommandOptionType.NoValue, Description = "Emit additional console output" )]
    public bool Verbose { get; set; }


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


        /*
         * Load attachments
         */
        if ( message.Attachments?.Count > 0 )
        {
            foreach ( var att in message.Attachments )
            {
                if ( att.Content != null )
                    continue;

                if ( File.Exists( att.Filename ) == false )
                {
                    Console.Error.WriteLine( "err: ES001: unable to load attachment from file {0}", att.Filename );
                    return 1;
                }

                if ( this.Verbose == true )
                    Console.WriteLine( "attachment: loading {0}...", att.Filename );

                var content = await File.ReadAllBytesAsync( att.Filename );
                att.Content = content;
            }
        }


        /*
         * 
         */
        if ( this.Verbose == true )
        {
            Console.WriteLine( "From: {0}", message.From.Email );
            Console.WriteLine( "  To: {0}", string.Join( ", ", message.To ) );
            Console.WriteLine( "Subj: {0}", message.Subject );

            if ( message.TextBody != null )
            {
                Console.WriteLine( "Body: Text", message.Subject );
                Console.WriteLine( "{0}", message.TextBody );
            }
            else
            {
                Console.WriteLine( "Body: Html", message.Subject );
                Console.WriteLine( "{0}", message.HtmlBody );
            }

            // TODO: headers
            // TODO: tags
            // TODO: attachments
        }


        /*
         * 
         */
        var res = await _resend.EmailSendAsync( message );

        Console.WriteLine( res.Content );

        return 0;
    }
}
