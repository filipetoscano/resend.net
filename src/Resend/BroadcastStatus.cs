using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Broadcast statuses.
/// </summary>
[JsonConverter( typeof( JsonStringEnumValueConverter<BroadcastStatus> ) )]
public enum BroadcastStatus
{
    /// <summary>
    /// Broadcast has not been sent.
    /// </summary>
    [JsonStringValue( "draft" )]
    Draft,

    /// <summary>
    /// Broadcast has been queued for sending.
    /// </summary>
    [JsonStringValue( "queued" )]
    Queued,

    /// <summary>
    /// Broadcast has been sent.
    /// </summary>
    [JsonStringValue( "sent" )]
    Sent,

    /// <summary>
    /// Broadcast is scheduled for delivery.
    /// </summary>
    [JsonStringValue( "scheduled" )]
    Scheduled,

    /// <summary>
    /// Broadcast failed to send.
    /// </summary>
    [JsonStringValue( "failed" )]
    Failed,
}
