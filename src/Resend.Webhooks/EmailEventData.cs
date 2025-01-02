using System.Text.Json.Serialization;

namespace Resend.Webhooks;

/// <summary />
public class EmailEventData : IWebhookData
{
    /// <summary />
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "email_id" )]
    public Guid EmailId { get; set; }

    /// <summary />
    [JsonPropertyName( "from" )]
    public EmailAddress From { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "to" )]
    public EmailAddressList To { get; set; } = default!;

    /// <summary />
    /// <remarks>
    /// Only set for <see cref="Resend.WebhookEventType.EmailClicked" />, otherwise is null.
    /// </remarks>
    [JsonPropertyName( "click" )]
    public EmailClickData? Click { get; set; }

    /// <summary />
    [JsonPropertyName( "subject" )]
    public string Subject { get; set; } = default!;
}


/// <summary />
public class EmailClickData
{
    /// <summary />
    [JsonPropertyName( "ipAddress" )]
    public string IpAddress { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "link" )]
    public string Link { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "timestamp" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentClicked { get; set; }

    /// <summary />
    [JsonPropertyName( "userAgent" )]
    public string UserAgent { get; set; } = default!;
}