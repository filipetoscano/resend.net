using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary>
/// Request object to create a Contact.
/// </summary>
public class ContactAddRequest
{
    /// <summary>
    /// The email address of the contact.
    /// </summary>
    [JsonPropertyName( "email" )]
    public string Email { get; set; } = default!;

    /// <summary>
    /// The first name of the contact.
    /// </summary>
    [JsonPropertyName( "first_name" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the contact.
    /// </summary>
    [JsonPropertyName( "last_name" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? LastName { get; set; }

    /// <summary>
    /// The last name of the contact.
    /// </summary>
    [JsonPropertyName( "unsubscribed" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public bool? IsUnsubscribed { get; set; }
}
