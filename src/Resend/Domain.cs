using Resend.Json;
using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
public class Domain
{
    /// <summary>
    /// Domain identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Domain name.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "status" )]
    public ValidationStatus Status { get; set; }

    /// <summary>
    /// Moment when the domain was created.
    /// </summary>
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentCreated { get; set; }

    /// <summary>
    /// Region from which the emails for this domain are delivered.
    /// </summary>
    [JsonPropertyName( "region" )]
    public DeliveryRegion Region { get; set; }

    /// <summary>
    /// DNS records used for domain validation.
    /// </summary>
    /// <remarks>
    /// When the domain is programatically created through API, these DNS records
    /// need to be added so that Resend can validate ownership of the domain.
    /// </remarks>
    [JsonPropertyName( "records" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<DomainRecord>? Records { get; set; }
}
