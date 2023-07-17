using System.Runtime.Serialization;

namespace Resend.Net;

/// <summary>
/// Permission when creating an API key.
/// </summary>
public enum Permission
{
    /// <summary>
    /// Can create, delete, get, and update any resource.
    /// </summary>
    [EnumMember( Value = "full_access" )]
    FullAccess,

    /// <summary>
    /// Can only send emails.
    /// </summary>
    [EnumMember( Value = "sending_access" )]
    SendingAccess,
}
