using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary>
/// Request object to create an API key.
/// </summary>
public class ApiKeyCreateRequest
{
    /// <summary>
    /// Name of API key.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Permissions to be granted to API key.
    /// </summary>
    [JsonPropertyName( "permission" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public Permission? Permission { get; set; }

    /// <summary>
    /// Domain for which the API key will be used.
    /// </summary>
    [JsonPropertyName( "domain_id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public Guid? DomainId { get; set; }
}
