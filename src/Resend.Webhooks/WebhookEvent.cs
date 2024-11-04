using System.Text.Json.Serialization;

namespace Resend.Webhooks;

/// <summary />
[JsonConverter( typeof( WebhookEventConverter ) )]
public class WebhookEvent
{
    /// <summary />
    [JsonPropertyName( "type" )]
    public Resend.WebhookEvent EventType { get; set; }

    /// <summary />
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "data" )]
    public IWebhookData Data { get; set; } = default!;


    /// <summary />
    public T DataAs<T>()
        where T : IWebhookData
    {
        return (T) this.Data;
    }
}
