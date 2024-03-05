using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Response when Audience is created.
/// </summary>
public class AudienceData
{
    /// <summary>
    /// API key identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;
}


/// <summary>
/// Properties of Audience.
/// </summary>
public class Audience
{
    /// <summary>
    /// Audience key identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Display name of the Audience.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Moment in which the Audience was created.
    /// </summary>
    [JsonPropertyName( "created_at" )]
    public DateTime MomentCreated { get; set; }
}