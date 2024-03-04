using System.Text.Json.Serialization;

namespace Resend.Payloads;

public class AudienceCreateRequest
{
    /// <summary>
    /// Name of Audience.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;
}

