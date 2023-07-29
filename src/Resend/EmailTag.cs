using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
public class EmailTag
{
    /// <summary>
    /// The name of the email tag.
    /// </summary>
    /// <remarks>
    /// It can only contain ASCII letters (a–z, A–Z), numbers (0–9), underscores (_), or dashes (-).
    /// It can contain no more than 256 characters.
    /// </remarks>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// The value of the email tag.
    /// </summary>
    /// <remarks>
    /// It can only contain ASCII letters (a–z, A–Z), numbers (0–9), underscores (_), or dashes (-).
    /// It can contain no more than 256 characters.
    /// </remarks>
    [JsonPropertyName( "value" )]
    public string Value { get; set; } = default!;
}
