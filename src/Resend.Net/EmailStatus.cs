using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<EmailStatus> ) )]
public enum EmailStatus
{
    /// <summary />
    [JsonStringValue( "sent" )]
    Sent,

    /// <summary />
    [JsonStringValue( "delivered" )]
    Delivered,

    /// <summary />
    [JsonStringValue( "delivery_delayed" )]
    DeliveryDelayed,

    /// <summary />
    [JsonStringValue( "complained" )]
    Complained,

    /// <summary />
    [JsonStringValue( "bounced" )]
    Bounced,

    /// <summary />
    [JsonStringValue( "clicked" )]
    Clicked,

    /// <summary />
    [JsonStringValue( "opened" )]
    Opened,
}
