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
}
