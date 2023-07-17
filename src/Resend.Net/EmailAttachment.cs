namespace Resend.Net;

/// <summary />
public class EmailAttachment
{
    /// <summary />
    public string Filename { get; set; } = default!;

    /// <summary />
    public byte[] Content { get; set; } = default!;
}
