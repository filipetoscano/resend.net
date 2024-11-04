using System.Text.Json.Serialization;

namespace Resend.Webhooks;

/// <summary />
public class ContactEventData : IWebhookData
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public Guid ContactId { get; set; }
}
