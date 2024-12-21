namespace Resend.Webhooks;

/// <summary />
public class WebhookValidation
{
    /// <summary>
    /// Unique message identifier.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary>
    /// Timestamp.
    /// </summary>
    public long? Timestamp { get; set; }

    /// <summary>
    /// Signature.
    /// </summary>
    public string? Signature { get; set; }

    /// <summary>
    /// Raw JSON payload.
    /// </summary>
    public string Payload { get; set; } = default!;

    /// <summary>
    /// Whether validation passed.
    /// </summary>
    public bool IsValid { get; set; }

    /// <summary>
    /// When validation fails, an exception will be set.
    /// </summary>
    public WebhookException? Exception { get; set; }
}