using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
public class DomainUpdateData
{
    /// <summary>
    /// Track clicks within the body of each HTML email.
    /// </summary>
    [JsonPropertyName( "click_tracking" )]
    public bool TrackClicks { get; set; } = default!;

    /// <summary>
    /// Track the open rate of each email.
    /// </summary>
    [JsonPropertyName( "open_tracking" )]
    public bool TrackOpen { get; set; } = default!;

    /// <summary>
    /// TLS mode.
    /// </summary>
    [JsonPropertyName( "tls" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public TlsMode? TlsMode { get; set; }
}


/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<TlsMode> ) )]
public enum TlsMode
{
    /// <summary>
    /// Opportunistic TLS means that it always attempts to make a
    /// secure connection to the receiving mail server. If it can't
    /// establish a secure connection, it sends the message unencrypted.
    /// </summary>
    [JsonStringValue( "opportunistic" )]
    Opportunistic = 1,

    /// <summary>
    /// Enforced TLS on the other hand, requires that the email
    /// communication must use TLS no matter what. If the
    /// receiving server does not support TLS, the email will
    /// not be sent.
    /// </summary>
    [JsonStringValue( "enforced" )]
    Enforced,
}