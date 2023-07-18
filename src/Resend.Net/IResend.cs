namespace Resend.Net;

/// <summary />
public interface IResend
{
    Task<Guid> EmailSendAsync( EmailMessage email, CancellationToken cancellationToken = default );

    Task<EmailReceipt> EmailRetrieveAsync( Guid emailId, CancellationToken cancellationToken = default );

    Task<List<ApiKey>> ApiKeyListAsync( CancellationToken cancellationToken = default );
}
