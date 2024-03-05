using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Response when Contact is created.
/// </summary>
public class ContactData
{
    /// <summary>
    /// Contact identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }
}


/// <summary>
/// Properties of Contact.
/// </summary>
public class Contact
{
    /// <summary>
    /// Contact identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

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
    /// The created date.
    /// </summary>
    [JsonPropertyName( "created_at" )]
    public DateTime MomentCreated { get; set; }

    /// <summary>
    /// The subscription status.
    /// </summary>
    [JsonPropertyName( "unsubscribed" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public bool? IsUnsubscribed { get; set; }
}
