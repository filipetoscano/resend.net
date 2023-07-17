using System.Runtime.Serialization;

namespace Resend.Net;

/// <summary>
/// Region/data center from which emails are sent from.
/// </summary>
public enum DeliveryRegion
{
    /// <summary>
    /// United States East (North Virginia)
    /// </summary>
    [EnumMember( Value = "us-east-1" )]
    UsEast1,

    /// <summary>
    /// Europe (Ireland)
    /// </summary>
    [EnumMember( Value = "eu-west-1" )]
    EuWest1,

    /// <summary>
    /// South America (Sao Paulo, Brazil).
    /// </summary>
    [EnumMember( Value = "sa-east-1" )]
    SaEast1,
}
