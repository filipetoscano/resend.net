using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Email attachment.
/// </summary>
public class EmailAttachment
{
    /// <summary>
    /// Name of the attached file.
    /// </summary>
    [JsonPropertyName( "filename" )]
    public string Filename { get; set; } = default!;

    /// <summary>
    /// Content of the attached file.
    /// </summary>
    [JsonPropertyName( "content" )]
    public byte[] Content { get; set; } = default!;
}
