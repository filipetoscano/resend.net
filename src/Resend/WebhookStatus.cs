using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<WebhookStatus> ) )]
public enum WebhookStatus
{
    /// <summary />
    [JsonStringValue( "enabled" )]
    Enabled,

    /// <summary />
    [JsonStringValue( "disabled" )]
    Disabled,
}
