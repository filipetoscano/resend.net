using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<WebhookStatus> ) )]
public enum WebhookStatus
{
    [JsonStringValue( "enabled" )]
    Enabled,

    [JsonStringValue( "disabled" )]
    Disabled,
}
