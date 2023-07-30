using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary />
public class ListOf<T>
{
    /// <summary />
    [JsonPropertyName( "data" )]
    public List<T> Data { get; set; } = default!;
}
