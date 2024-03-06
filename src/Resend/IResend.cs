﻿namespace Resend;

/// <summary>
/// Resend client.
/// </summary>
public interface IResend
{
    /// <summary>
    /// Send an email.
    /// </summary>
    /// <param name="email">
    /// Email.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Email identifier.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/emails/send-email"/>
    Task<ResendResponse<Guid>> EmailSendAsync( EmailMessage email, CancellationToken cancellationToken = default );


    /// <summary>
    /// Retrieves the email receipt for the given email.
    /// </summary>
    /// <param name="emailId">
    /// Email identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Email receipt.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/emails/retrieve-email"/>
    Task<ResendResponse<EmailReceipt>> EmailRetrieveAsync( Guid emailId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Retrieve a list of domains for the authenticated user.
    /// </summary>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Domain.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/domains/list-domains"/>
    Task<ResendResponse<List<Domain>>> DomainListAsync( CancellationToken cancellationToken = default );


    /// <summary>
    /// Create a (sender) domain.
    /// </summary>
    /// <param name="domainName">
    /// Domain DNS name.
    /// </param>
    /// <param name="region">
    /// Delivery region.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Domain.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/domains/create-domain"/>
    Task<ResendResponse<Domain>> DomainAddAsync( string domainName, DeliveryRegion? region, CancellationToken cancellationToken = default );


    /// <summary>
    /// Retrieves a domain.
    /// </summary>
    /// <param name="domainId">
    /// Domain identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Domain.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/domains/get-domain"/>
    Task<ResendResponse<Domain>> DomainRetrieveAsync( Guid domainId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Verify an existing domain.
    /// </summary>
    /// <param name="domainId">
    /// Domain identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Task.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/domains/verify-domain"/>
    Task<ResendResponse> DomainVerifyAsync( Guid domainId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Remove an existing domain.
    /// </summary>
    /// <param name="domainId">
    /// Domain identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Task.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/domains/delete-domain"/>
    Task<ResendResponse> DomainDeleteAsync( Guid domainId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Lists all defined API keys.
    /// </summary>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>List of API keys</returns>
    /// <see href="https://resend.com/docs/api-reference/api-keys/list-api-keys"/>
    Task<ResendResponse<List<ApiKey>>> ApiKeyListAsync( CancellationToken cancellationToken = default );


    /// <summary>
    /// Add a new API key to authenticate communications with Resend.
    /// </summary>
    /// <param name="keyName">
    /// Name of the API key.
    /// </param>
    /// <param name="permission">
    /// Permissions that apply to the API key.
    /// </param>
    /// <param name="domainId">
    /// Restrict an API key to send emails only from a specific domain. Only used when
    /// the permission is FullAccess.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// API key data. The token is only available during creation!
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/api-keys/create-api-key"/>
    Task<ResendResponse<ApiKeyData>> ApiKeyCreateAsync( string keyName, Permission? permission = null, Guid? domainId = null, CancellationToken cancellationToken = default );


    /// <summary>
    /// Remove an existing API key.
    /// </summary>
    /// <param name="apiKeyId">
    /// API key identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Task.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/api-keys/delete-api-key" />
    Task<ResendResponse> ApiKeyDelete( Guid apiKeyId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Create a list of contacts.
    /// </summary>
    /// <param name="name">
    /// The name of the audience you want to create..
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Task.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/audiences/create-audience" />
    Task<ResendResponse<AudienceData>> AudienceAddAsync( string name, CancellationToken cancellationToken = default );


    /// <summary>
    /// Retrieve a single audience.
    /// </summary>
    /// /// <param name="audienceId">
    /// The audience identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// List of Audience.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/audiences/get-audience" />
    Task<ResendResponse<Audience>> AudienceRetrieveAsync( Guid audienceId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Remove an existing audience.
    /// </summary>
    /// <param name="audienceId">
    /// The Audience ID.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// Task.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/audiences/delete-audience" />
    Task<ResendResponse> AudienceDeleteAsync( Guid audienceId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Retrieve a list of audiences.
    /// </summary>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// A list of Audience.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/audiences/list-audiences" />
    Task<ResendResponse<List<Audience>>> AudienceListAsync( CancellationToken cancellationToken = default );


    /// <summary>
    /// Create a contact inside an audience.
    /// </summary>
    /// /// <param name="audienceId">
    /// The Audience ID.
    /// </param>
    /// <param name="email">
    /// The email address of the contact.
    /// </param>
    /// <param name="firstName">
    /// The first name of the contact.
    /// </param>
    /// <param name="lastName">
    /// The last name of the contact.
    /// </param>
    /// <param name="unsubscribed">
    /// The subscription status.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelation token.
    /// </param>
    /// <returns>
    /// Contact Id. 
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/contacts/create-contact" />
    Task<ResendResponse<ContactData>> ContactAddAsync( Guid audienceId, string email, string? firstName = default, string? lastName = default, bool? unsubscribed = default, CancellationToken cancellationToken = default );


    /// <summary>
    /// Retrieve a single contact from an audience.
    /// </summary>
    /// <param name="audienceId">
    /// The Audience ID.
    /// </param>
    /// <param name="contactId">
    /// The Contact ID.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelation token.
    /// </param>
    /// <returns>
    /// A Contact.
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/contacts/get-contact" />
    Task<ResendResponse<Contact>> ContactRetrieveAsync( Guid audienceId, Guid contactId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Update an existing contact.
    /// </summary>
    /// <param name="audienceId">
    /// The Audience ID.
    /// </param>
    /// <param name="contactId">
    /// The Contact ID.
    /// </param>
    /// <param name="email">
    /// The email address of the contact. 
    /// </param>
    /// <param name="firstName">
    /// The first name of the contact.
    /// </param>
    /// <param name="lastName">
    /// The last name of the contact.
    /// </param>
    /// <param name="unsubscribed">
    /// The subscription status.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelation token.
    /// </param>
    /// <returns>
    /// Contact Id. 
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/contacts/update-contact" />
    Task<ResendResponse<ContactData>> ContactUpdateAsync( Guid audienceId, Guid contactId, string email, string? firstName = default, string? lastName = default, bool? unsubscribed = default, CancellationToken cancellationToken = default );


    /// <summary>
    /// Remove a contact.
    /// </summary>
    /// <param name="audienceId">
    /// Audience identifier.
    /// </param>
    /// <param name="contactId">
    /// Contact identifier.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelation token.
    /// </param>
    /// <returns>
    /// Task
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/contacts/delete-contact" />
    Task<ResendResponse> ContactDeleteAsync( Guid audienceId, Guid contactId, CancellationToken cancellationToken = default );


    /// <summary>
    /// Remove a contact by their email address.
    /// </summary>
    /// <param name="audienceId">
    /// Audience identifier.
    /// </param>
    /// <param name="email">
    /// Email address of the contact.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelation token.
    /// </param>
    /// <returns>
    /// Task
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/contacts/delete-contact" />
    Task<ResendResponse> ContactDeleteByEmailAsync( Guid audienceId, string email, CancellationToken cancellationToken = default );



    /// <summary>
    /// Show all contacts from an audience.
    /// </summary>
    /// <param name="audienceId">
    /// The Audience ID.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancelation token.
    /// </param>
    /// <returns>
    /// List of contacts. 
    /// </returns>
    /// <see href="https://resend.com/docs/api-reference/contacts/list-contacts" />
    Task<ResendResponse<List<Contact>>> ContactListAsync( Guid audienceId, CancellationToken cancellationToken = default );
}
