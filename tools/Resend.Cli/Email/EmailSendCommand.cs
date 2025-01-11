﻿using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace Resend.Cli.Email;

/// <summary />
[Command( "send", Description = "Sends an email" )]
public class EmailSendCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Input JSON file" )]
    [FileExists]
    public string? InputFile { get; set; }

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
        string json;

        if ( Console.IsInputRedirected == true )
        {
            json = await Console.In.ReadToEndAsync();
        }
        else
        {
            var ifile = this.InputFile ?? "email.json";

            if ( File.Exists( ifile ) == false )
            {
                var of = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "The file '{0}' does not exist.", ifile );
                Console.ForegroundColor = of;

                return 1;
            }

            json = File.ReadAllText( ifile );
        }

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

                if ( att.Path != null )
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

            if ( message.HtmlBody != null )
            {
                Console.WriteLine( "Body: Html", message.Subject );
                Console.WriteLine( "{0}", message.HtmlBody );
            }

            if ( message.TextBody != null )
            {
                Console.WriteLine( "Body: Text", message.Subject );
                Console.WriteLine( "{0}", message.TextBody );
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


        /*
         * 
         */
        if ( this.Verbose == true && res.Limits != null )
        {
            Console.WriteLine( "Policy={0}", res.Limits.Policy );
            Console.WriteLine( "Limit={0}", res.Limits.Limit );
            Console.WriteLine( "Remaining={0}", res.Limits.Remaining );
            Console.WriteLine( "Reset={0}", res.Limits.Reset );
            Console.WriteLine( "RetryAfter={0}", res.Limits.RetryAfter );
        }

        return 0;
    }
}
