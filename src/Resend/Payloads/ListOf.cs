using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary>
/// Resend response, when the method returns an array of a class.
/// </summary>
public class ListOf<T>
{
    /// <summary />
    [JsonPropertyName( "data" )]
    public List<T> Data { get; set; } = default!;
}
