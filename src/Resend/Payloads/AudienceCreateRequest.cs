using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary>
/// Request object to create an Audience.
/// </summary>
public class AudienceCreateRequest
{
    /// <summary>
    /// Name of Audience.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;
}
