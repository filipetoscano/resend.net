using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Email statuses.
/// </summary>
[JsonConverter( typeof( JsonStringEnumValueConverter<EmailStatus> ) )]
public enum EmailStatus
{
    /// <summary>
    /// Email has been sent by Resend.
    /// </summary>
    [JsonStringValue( "sent" )]
    Sent,

    /// <summary>
    /// Email has been delivered to recipient.
    /// </summary>
    [JsonStringValue( "delivered" )]
    Delivered,

    /// <summary>
    /// Email 
    /// </summary>
    [JsonStringValue( "delivery_delayed" )]
    DeliveryDelayed,

    /// <summary>
    /// Recipient has filed a complaint.
    /// </summary>
    [JsonStringValue( "complained" )]
    Complained,

    /// <summary>
    /// Email bounced (for whatever reason).
    /// </summary>
    [JsonStringValue( "bounced" )]
    Bounced,

    /// <summary>
    /// Links in the email have been clicked on by recipient.
    /// </summary>
    /// <remarks>
    /// This status is only available if the 'Click Tracking' option has
    /// been enabled for the domain.
    /// </remarks>
    [JsonStringValue( "clicked" )]
    Clicked,

    /// <summary>
    /// Email has been opened by recipient.
    /// </summary>
    /// <remarks>
    /// This status is only available if the 'Open Tracking' option has
    /// been enabled for the domain.
    /// </remarks>
    [JsonStringValue( "opened" )]
    Opened,
}
