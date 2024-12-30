using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Broadcast statuses.
/// </summary>
[JsonConverter( typeof( JsonStringEnumValueConverter<BroadcastStatus> ) )]
public enum BroadcastStatus
{
    /// <summary />
    [JsonStringValue( "draft" )]
    Draft,

    /// <summary />
    [JsonStringValue( "sent" )]
    Sent,
}
