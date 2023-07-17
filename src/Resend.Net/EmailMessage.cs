using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend.Net;

/// <summary />
public class EmailMessage
{
    /// <summary>
    /// Sender email address.
    /// </summary>
    public EmailAddress From { get; set; } = default!;

    /// <summary>
    /// Recipient email address.
    /// </summary>
    public List<string> To { get; set; } = default!;

    /// <summary>
    /// Email subject.
    /// </summary>
    public string Subject { get; set; } = default!;

    /// <summary>
    /// Cc/carbon-copy recipient email address.
    /// </summary>
    public List<string>? Cc { get; set; }

    /// <summary>
    /// Bcc/blind carbon copy recipient email address.
    /// </summary>
    public List<string>? Bcc { get; set; }

    /// <summary>
    /// Reply-to email address.
    /// </summary>
    public List<string>? ReplyTo { get; set; }


    /// <summary>
    /// The plain text version of the message.
    /// </summary>
    public string? TextBody { get; set; }

    /// <summary>
    /// The HTML version of the message.
    /// </summary>
    public string? HtmlBody { get; set; }


    /// <summary>
    /// Custom headers to add to the email.
    /// </summary>
    public Dictionary<string,string>? Headers { get; set; }

    /// <summary>
    /// Email tags.
    /// </summary>
    public List<EmailTag>? Tags { get; set; }
}
