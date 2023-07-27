using FluentEmail.Core;
using FluentEmail.Core.Models;
using Resend.Net;

namespace Resend.FluentEmail;

/// <summary>
/// FluendEmail implementation for Resend.
/// </summary>
public class ResendSender : IResendSender
{
    private readonly IResend _resend;

    /// <summary />
    public ResendSender( IResend resend )
    {
        _resend = resend;
    }


    /// <inheritdoc />
    public SendResponse Send( IFluentEmail email, CancellationToken? token = null )
    {
        var task = SendAsync( email, token );

        return task.GetAwaiter().GetResult();
    }


    /// <inheritdoc />
    public async Task<SendResponse> SendAsync( IFluentEmail email, CancellationToken? token = null )
    {
        var message = ToMessage( email );

        var resp = await _resend.EmailSendAsync( message, token ?? CancellationToken.None );

        // TODO: error handling

        return new SendResponse()
        {
            MessageId = resp.ToString(),
        };
    }


    /// <summary />
    private static EmailMessage ToMessage( IFluentEmail email )
    {
        var message = new EmailMessage();
        message.Headers = new Dictionary<string, string>();
        message.Tags = new List<EmailTag>();


        /*
         * Basics
         */
        message.Subject = email.Data.Subject;
        message.From = email.Data.FromAddress.EmailAddress;
        message.To.AddRange( email.Data.ToAddresses.Select( x => x.EmailAddress ) );

        if ( email.Data.CcAddresses.Count > 0 )
            message.Cc = email.Data.CcAddresses.Select( x => x.EmailAddress ).ToList();

        if ( email.Data.BccAddresses.Count > 0 )
            message.Bcc = email.Data.BccAddresses.Select( x => x.EmailAddress ).ToList();

        if ( email.Data.ReplyToAddresses.Count > 0 )
            message.ReplyTo = email.Data.ReplyToAddresses.Select( x => x.EmailAddress ).ToList();


        /*
         * Body
         */
        if ( email.Data.IsHtml == true )
            message.HtmlBody = email.Data.Body;
        else
            message.TextBody = email.Data.Body;


        /*
         * Priority
         */
        switch ( email.Data.Priority )
        {
            case Priority.High:
                // https://docs.microsoft.com/en-us/openspecs/exchange_server_protocols/ms-oxcmail/2bb19f1b-b35e-4966-b1cb-1afd044e83ab
                message.Headers.Add( "X-Priority", "1" );
                message.Headers.Add( "X-MSMail-Priority", "High" );
                break;

            case Priority.Normal:
                // Do not set anything.
                // Leave default values. It means Normal Priority.
                break;

            case Priority.Low:
                // https://docs.microsoft.com/en-us/openspecs/exchange_server_protocols/ms-oxcmail/2bb19f1b-b35e-4966-b1cb-1afd044e83ab
                message.Headers.Add( "X-Priority", "5" );
                message.Headers.Add( "X-MSMail-Priority", "Low" );
                break;
        }


        /*
         * Headers
         */
        if ( email.Data.Headers.Count > 0 )
        {
            foreach ( var kv in email.Data.Headers )
            {
                if ( message.Headers.ContainsKey( kv.Key ) == true )
                    message.Headers[ kv.Key ] = kv.Value;
                else
                    message.Headers.Add( kv.Key, kv.Value );
            }
        }


        /*
         * Tags
         */
        if ( email.Data.Tags.Count > 0 )
        {
            message.Tags.AddRange( email.Data.Tags.Select( x => new EmailTag()
            {
                Name = x,
                Value = "1",
            } ) );
        }


        /*
         * Attachments
         */
        // TODO

        return message;
    }
}
