using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<WebhookEvent> ) )]
public enum WebhookEvent
{
    /// <summary />
    [JsonStringValue( "email.sent" )]
    EmailSent,

    /// <summary />
    [JsonStringValue( "email.delivered" )]
    EmailDelivered,

    /// <summary />
    [JsonStringValue( "email.delivery_delayed" )]
    EmailDeliveryDelay,

    /// <summary />
    [JsonStringValue( "email.complained" )]
    EmailComplained,

    /// <summary />
    [JsonStringValue( "email.bounced" )]
    EmailBounced,

    /// <summary />
    [JsonStringValue( "email.clicked" )]
    EmailClicked,

    /// <summary />
    [JsonStringValue( "email.opened" )]
    EmailOpened,
}
