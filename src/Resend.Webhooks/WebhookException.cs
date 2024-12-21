namespace Resend.Webhooks;

/// <summary>
/// Exception when processing a webhook event.
/// </summary>
public class WebhookException : ApplicationException
{
    /// <summary>
    /// Initializes a new instance of WebhookException.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    /// <param name="message">Error message.</param>
    public WebhookException( string errorCode, string message )
        : base( message )
    {
        this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Gets the Webhook error code.
    /// </summary>
    public string ErrorCode { get; }
}