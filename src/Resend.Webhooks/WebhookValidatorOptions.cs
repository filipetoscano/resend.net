namespace Resend.Webhooks;

/// <summary />
public class WebhookValidatorOptions
{
    /// <summary>
    /// Signing secret.
    /// </summary>
    /// <remarks>
    /// Obtained from the Resend UI after creating a webhook.
    /// </remarks>
    public string Secret { get; set; } = default!;
}