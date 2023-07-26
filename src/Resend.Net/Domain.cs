using System.Text.Json.Serialization;

namespace Resend.Net;

/// <summary />
public class Domain
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "status" )]
    public DomainStatus Status { get; set; }

    /// <summary />
    [JsonPropertyName( "created_at" )]
    public DateTime MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "region" )]
    public DeliveryRegion Region { get; set; }

    /// <summary />
    [JsonPropertyName( "records" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<DomainRecord>? Record { get; set; }
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

    /// <summary />
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
    public DomainStatus Status { get; set; }
}


/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<DomainStatus> ) )]
public enum DomainStatus
{
    /// <summary />
    [JsonStringValue( "not_started" )]
    NotStarted,

    /// <summary />
    [JsonStringValue( "pending" )]
    Pending,
}
