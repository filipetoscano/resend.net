using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary />
internal class DomainAddRequest
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "region" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public DeliveryRegion? Region { get; set; }
}
