namespace Resend;

/// <summary />
public static class ResendExtensions
{
    /// <summary>
    /// Returns the event category for a given event type.
    /// </summary>
    public static WebhookEventTypeCategory Category( this WebhookEvent @event )
    {
        switch ( @event )
        {
            case WebhookEvent.DomainCreated:
            case WebhookEvent.DomainUpdated:
            case WebhookEvent.DomainDeleted:
                return WebhookEventTypeCategory.Domain;

            case WebhookEvent.ContactCreated:
            case WebhookEvent.ContactUpdated:
            case WebhookEvent.ContactDeleted:
                return WebhookEventTypeCategory.Contact;

            case WebhookEvent.EmailBounced:
            case WebhookEvent.EmailClicked:
            case WebhookEvent.EmailComplained:
            case WebhookEvent.EmailDelivered:
            case WebhookEvent.EmailDeliveryDelay:
            case WebhookEvent.EmailOpened:
            case WebhookEvent.EmailSent:
                return WebhookEventTypeCategory.Email;

            default:
                throw new NotSupportedException();
        }
    }
}