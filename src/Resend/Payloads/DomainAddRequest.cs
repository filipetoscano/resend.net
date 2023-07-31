using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary>
/// Request object to create an email sender domain.
/// </summary>
public class DomainAddRequest
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "region" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public DeliveryRegion? Region { get; set; }
}
