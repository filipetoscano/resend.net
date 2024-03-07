using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary>
/// Resend response, when the method only returns the (newly created)
/// object identifier.
/// </summary>
public class ObjectId
{
    /// <summary>
    /// Object type.
    /// </summary>
    [JsonPropertyName( "object" )]
    public string Object { get; set; } = default!;

    /// <summary>
    /// Object identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }
}
