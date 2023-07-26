using System.Text.Json.Serialization;

namespace Resend.Net;

/// <summary>
/// Region/data center from which emails are sent from.
/// </summary>
[JsonConverter( typeof( JsonStringEnumValueConverter<DeliveryRegion> ) )]
public enum DeliveryRegion
{
    /// <summary>
    /// United States East (North Virginia)
    /// </summary>
    [JsonStringValue( "us-east-1" )]
    UsEast1,

    /// <summary>
    /// Europe (Ireland)
    /// </summary>
    [JsonStringValue( "eu-west-1" )]
    EuWest1,

    /// <summary>
    /// South America (Sao Paulo, Brazil).
    /// </summary>
    [JsonStringValue( "sa-east-1" )]
    SaEast1,
}
