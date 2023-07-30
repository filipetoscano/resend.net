using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary />
public class ObjectId
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }
}
