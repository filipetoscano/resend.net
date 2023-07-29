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


/// <summary />
public class DomainRecord
{
    /// <summary />
    [JsonPropertyName( "record" )]
    public string Record { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "value" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? Value { get; set; }

    /// <summary>
    /// Type of DNS record to be added.
    /// </summary>
    [JsonPropertyName( "type" )]
    public string RecordType { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "ttl" )]
    public string TimeToLive { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "priority" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Priority { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "status" )]
    public ValidationStatus Status { get; set; }
}


/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<ValidationStatus> ) )]
public enum ValidationStatus
{
    /// <summary>
    /// Validation has not started.
    /// </summary>
    [JsonStringValue( "not_started" )]
    NotStarted,

    /// <summary>
    /// Validation has been started and is currently executing.
    /// </summary>
    /// <remarks>
    /// May take up to 72h to conclude.
    /// </remarks>
    [JsonStringValue( "pending" )]
    Pending,
}
