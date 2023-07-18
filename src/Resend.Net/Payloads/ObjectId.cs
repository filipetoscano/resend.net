using System.Text.Json.Serialization;

namespace Resend.Net.Payloads;

/// <summary />
internal class ObjectId
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }
}
