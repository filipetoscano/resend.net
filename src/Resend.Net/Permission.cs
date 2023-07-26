using System.Text.Json.Serialization;

namespace Resend.Net;

/// <summary>
/// Permission when creating an API key.
/// </summary>
[JsonConverter( typeof( JsonStringEnumValueConverter<Permission> ) )]
public enum Permission
{
    /// <summary>
    /// Can create, delete, get, and update any resource.
    /// </summary>
    [JsonStringValue( "full_access" )]
    FullAccess,

    /// <summary>
    /// Can only send emails.
    /// </summary>
    [JsonStringValue( "sending_access" )]
    SendingAccess,
}
