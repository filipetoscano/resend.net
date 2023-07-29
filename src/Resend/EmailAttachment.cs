using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
public class EmailAttachment
{
    /// <summary />
    [JsonPropertyName( "filename" )]
    public string Filename { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "content" )]
    public byte[] Content { get; set; } = default!;
}
