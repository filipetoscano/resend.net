using System.Text.Json.Serialization;

namespace Resend.Net;

/// <summary />
public class EmailMessage
{
    /// <summary>
    /// Sender email address.
    /// </summary>
    [JsonPropertyName( "from" )]
    public EmailAddress From { get; set; } = default!;

    /// <summary>
    /// Recipient email address (list).
    /// </summary>
    [JsonPropertyName( "to" )]
    public List<string> To { get; set; } = new List<string>();

    /// <summary>
    /// Email subject.
    /// </summary>
    [JsonPropertyName( "subject" )]
    public string Subject { get; set; } = default!;

    /// <summary>
    /// Cc/carbon-copy recipient email address.
    /// </summary>
    [JsonPropertyName( "cc" )]
    public List<string>? Cc { get; set; }

    /// <summary>
    /// Bcc/blind carbon copy recipient email address.
    /// </summary>
    [JsonPropertyName( "bcc" )]
    public List<string>? Bcc { get; set; }

    /// <summary>
    /// Reply-to email address.
    /// </summary>
    [JsonPropertyName( "reply_to" )]
    public List<string>? ReplyTo { get; set; }


    /// <summary>
    /// The plain text version of the message.
    /// </summary>
    [JsonPropertyName( "text" )]
    public string? TextBody { get; set; }

    /// <summary>
    /// The HTML version of the message.
    /// </summary>
    [JsonPropertyName( "html" )]
    public string? HtmlBody { get; set; }


    /// <summary>
    /// Custom headers to add to the email.
    /// </summary>
    [JsonPropertyName( "headers" )]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// Filename and content of attachments (max 40mb per email).
    /// </summary>
    [JsonPropertyName( "attachments" )]
    public List<EmailAttachment>? Attachments { get; set; }

    /// <summary>
    /// Email tags.
    /// </summary>
    [JsonPropertyName( "tags" )]
    public List<EmailTag>? Tags { get; set; }
}
