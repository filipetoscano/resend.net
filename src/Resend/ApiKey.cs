using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Response when API key is created.
/// </summary>
public class ApiKeyData
{
    /// <summary>
    /// API key identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Secret token / API key.
    /// </summary>
    [JsonPropertyName( "token" )]
    public string Token { get; set; } = default!;
}


/// <summary>
/// Properties of API keys defined in the account.
/// </summary>
public class ApiKey
{
    /// <summary>
    /// API key identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Display name of the API key.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Moment in which the API key was created.
    /// </summary>
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentCreated { get; set; }
}
