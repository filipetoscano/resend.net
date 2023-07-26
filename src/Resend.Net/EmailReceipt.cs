using System.Text.Json.Serialization;

namespace Resend.Net;

/// <summary />
public class EmailReceipt
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Sender email address.
    /// </summary>
    [JsonPropertyName( "from" )]
    public EmailAddress From { get; set; } = default!;

    /// <summary>
    /// Recipient email address.
    /// </summary>
    [JsonPropertyName( "to" )]
    public List<string> To { get; set; } = default!;

    /// <summary>
    /// Cc/carbon-copy recipient email address.
    /// </summary>
    [JsonPropertyName( "cc" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<string>? Cc { get; set; }

    /// <summary>
    /// Bcc/blind carbon copy recipient email address.
    /// </summary>
    [JsonPropertyName( "bcc" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<string>? Bcc { get; set; }

    /// <summary>
    /// Reply-to email address.
    /// </summary>
    [JsonPropertyName( "reply_to" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<string>? ReplyTo { get; set; }

    /// <summary>
    /// Email subject.
    /// </summary>
    [JsonPropertyName( "subject" )]
    public string Subject { get; set; } = default!;


    /// <summary>
    /// The plain text version of the message.
    /// </summary>
    [JsonPropertyName( "text" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? TextBody { get; set; }

    /// <summary>
    /// The HTML version of the message.
    /// </summary>
    [JsonPropertyName( "html" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? HtmlBody { get; set; }


    /// <summary />
    [JsonPropertyName( "created_at" )]
    public DateTime MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "last_event" )]
    [JsonConverter( typeof( JsonStringEnumConverter ) )]
    public EmailStatus? LastEvent { get; set; }
}
