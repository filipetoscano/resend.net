using System.Text.Json.Serialization;

namespace Resend.Net.Payloads;

/// <summary />
internal class ListOf<T>
{
    /// <summary />
    [JsonPropertyName( "data" )]
    public List<T> Data { get; set; } = default!;
}
