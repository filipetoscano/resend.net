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
}
