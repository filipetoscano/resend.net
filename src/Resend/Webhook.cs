using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
public class Webhook
{
    /// <summary>
    /// Domain identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Endpoint URL.
    /// </summary>
    [JsonPropertyName( "endpoint" )]
    public string EndpointUrl { get; set; } = default!;

    /// <summary>
    /// Moment in which endpoint was created.
    /// </summary>
    [JsonPropertyName( "created_at" )]
    public DateTime MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "events" )]
    public List<WebhookEvent> Events { get; set; } = default!;
}
