using System.Text.Json.Serialization;

namespace Resend;

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
