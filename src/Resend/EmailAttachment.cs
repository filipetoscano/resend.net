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
    /// Path where the attachment file is hosted.
    /// </summary>
    /// <remarks>
    /// One of <see cref="Path"/> or <see cref="Content"/> must be set.
    /// </remarks>
    [JsonPropertyName( "path" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public Uri? Path { get; set; }

    /// <summary>
    /// Content of the attached file.
    /// </summary>
    [JsonPropertyName( "content" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public byte[]? Content { get; set; }

    /// <summary>
    /// Content type for the attachment, if not set will be derived from the filename property.
    /// </summary>
    [JsonPropertyName( "content_type" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? ContentType { get; set; }
}
