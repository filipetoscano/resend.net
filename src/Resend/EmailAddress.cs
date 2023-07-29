using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Email address.
/// </summary>
[JsonConverter( typeof( EmailAddressConverter ) )]
public class EmailAddress
{
    /// <summary>
    /// Email address.
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Friendly name.
    /// </summary>
    public string? FriendlyName { get; set; }


    /// <summary />
    public static implicit operator EmailAddress( string email ) => new EmailAddress() { Email = email };
}
