using Microsoft.Extensions.Options;
using Resend.Payloads;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;

namespace Resend;

/// <summary>
/// Resend client implementation.
/// </summary>
public class ResendClient : IResend
{
    private readonly bool _throw;
    private readonly HttpClient _http;


    /// <summary>
    /// Initializes a new instance of ResendClient client.
    /// </summary>
    /// <param name="options">
    /// Configuration options.
    /// </param>
    /// <param name="httpClient">
    /// HTTP client instance.
    /// </param>
    public ResendClient( IOptions<ResendClientOptions> options, HttpClient httpClient )
    {
        /*
         * Authentication
         */
        var opt = options.Value;

        httpClient.BaseAddress = new Uri( opt.ApiUrl );
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", opt.ApiToken );


        /*
         * Ask for JSON responses. Not necessary atm, since Resend always/only
         * answers in JSON -- but good for future proofing.
         */
        httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );


        /*
         * Identification
         */
        var productValue = new ProductInfoHeaderValue( "resend-sdk", Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0" );
        var dotnetValue = new ProductInfoHeaderValue( "dotnet", Environment.Version.ToString() );

        httpClient.DefaultRequestHeaders.UserAgent.Add( productValue );
        httpClient.DefaultRequestHeaders.UserAgent.Add( dotnetValue );

        _http = httpClient;
        _throw = options.Value.ThrowExceptions;
    }


    /// <inheritdoc />
    public async Task<ResendResponse<Guid>> EmailSendAsync( EmailMessage email, CancellationToken cancellationToken = default )
    {
        var resp = await _http.PostAsJsonAsync( "/emails", email, cancellationToken );

        return await Handle<ObjectId, Guid>( resp, ( x ) => x.Id, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<EmailReceipt>> EmailRetrieveAsync( Guid emailId, CancellationToken cancellationToken = default )
    {
        var path = $"/emails/{emailId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<EmailReceipt, EmailReceipt>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<List<Guid>>> EmailBatchAsync( IEnumerable<EmailMessage> emails, CancellationToken cancellationToken = default )
    {
        var path = $"/emails/batch";
        var resp = await _http.PostAsJsonAsync( path, emails, cancellationToken );

        return await Handle<ListOf<ObjectId>, List<Guid>>( resp, ( x ) => x.Data.Select( y => y.Id ).ToList(), cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> EmailRescheduleAsync( Guid emailId, DateTime rescheduleFor, CancellationToken cancellationToken = default )
    {
        var req = new EmailRescheduleRequest()
        {
            MomentSchedule = rescheduleFor,
        };

        var path = $"/emails/{emailId}";
        var resp = await _http.PatchAsJsonAsync( path, req, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> EmailCancelAsync( Guid emailId, CancellationToken cancellationToken = default )
    {
        var path = $"emails/{emailId}/cancel";
        var resp = await _http.PostAsync( path, null, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<Domain>> DomainAddAsync( string domainName, DeliveryRegion? region, CancellationToken cancellationToken = default )
    {
        var req = new DomainAddRequest()
        {
            Name = domainName,
            Region = region,
        };

        var path = $"/domains";
        var resp = await _http.PostAsJsonAsync( path, req, cancellationToken );

        return await Handle<Domain, Domain>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<Domain>> DomainRetrieveAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<Domain, Domain>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> DomainUpdateAsync( Guid domainId, DomainUpdateData data, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";
        var resp = await _http.PatchAsJsonAsync( path, data, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> DomainVerifyAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}/verify";
        var content = new StringContent( "" );

        var resp = await _http.PostAsync( path, content, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<List<Domain>>> DomainListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/domains";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<Domain>, List<Domain>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> DomainDeleteAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";
        var resp = await _http.DeleteAsync( path, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<ApiKeyData>> ApiKeyCreateAsync( string keyName, Permission? permission = null, Guid? domainId = null, CancellationToken cancellationToken = default )
    {
        var req = new ApiKeyCreateRequest()
        {
            Name = keyName,
            Permission = permission,
            DomainId = domainId,
        };

        var path = $"/api-keys";
        var resp = await _http.PostAsJsonAsync( path, req, cancellationToken );

        return await Handle<ApiKeyData, ApiKeyData>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<List<ApiKey>>> ApiKeyListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/api-keys";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<ApiKey>, List<ApiKey>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> ApiKeyDelete( Guid apiKeyId, CancellationToken cancellationToken = default )
    {
        var path = $"/api-keys/{apiKeyId}";
        var resp = await _http.DeleteAsync( path, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<List<Webhook>>> WebhookListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/webhooks";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<Webhook>, List<Webhook>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<Guid>> AudienceAddAsync( string name, CancellationToken cancellationToken = default )
    {
        var req = new AudienceAddRequest()
        {
            Name = name
        };

        var path = $"/audiences";
        var resp = await _http.PostAsJsonAsync( path, req, cancellationToken );

        return await Handle<ObjectId, Guid>( resp, ( x ) => x.Id, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<Audience>> AudienceRetrieveAsync( Guid audienceId, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<Audience, Audience>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> AudienceDeleteAsync( Guid audienceId, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}";
        var resp = await _http.DeleteAsync( path, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<List<Audience>>> AudienceListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/audiences";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<Audience>, List<Audience>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<Guid>> ContactAddAsync( Guid audienceId, ContactData data, CancellationToken cancellationToken = default )
    {
        if ( data.Email == null )
            throw new ArgumentException( "Email must be non-null when creating contact", nameof( data ) + ".Email" );

        var path = $"/audiences/{audienceId}/contacts";
        var resp = await _http.PostAsJsonAsync( path, data, cancellationToken );

        return await Handle<ObjectId, Guid>( resp, ( x ) => x.Id, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<Contact>> ContactRetrieveAsync( Guid audienceId, Guid contactId, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}/contacts/{contactId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<Contact, Contact>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> ContactUpdateAsync( Guid audienceId, Guid contactId, ContactData data, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}/contacts/{contactId}";
        var resp = await _http.PatchAsJsonAsync( path, data, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> ContactDeleteAsync( Guid audienceId, Guid contactId, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}/contacts/{contactId}";
        var resp = await _http.DeleteAsync( path, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> ContactDeleteByEmailAsync( Guid audienceId, string email, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}/contacts/{email}";
        var resp = await _http.DeleteAsync( path, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<List<Contact>>> ContactListAsync( Guid audienceId, CancellationToken cancellationToken = default )
    {
        var path = $"/audiences/{audienceId}/contacts";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<Contact>, List<Contact>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<Guid>> BroadcastAddAsync( BroadcastData data, CancellationToken cancellationToken = default )
    {
        var path = $"/broadcasts";
        var resp = await _http.PostAsJsonAsync( path, data, cancellationToken );

        return await Handle<ObjectId, Guid>( resp, ( x ) => x.Id, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<Broadcast>> BroadcastRetrieveAsync( Guid broadcastId, CancellationToken cancellationToken = default )
    {
        var path = $"/broadcasts/{broadcastId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<Broadcast, Broadcast>( resp, ( x ) => x, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> BroadcastSendAsync( Guid broadcastId, CancellationToken cancellationToken = default )
    {
        var req = new { };

        var path = $"/broadcasts/{broadcastId}/send";
        var resp = await _http.PostAsJsonAsync( path, req, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> BroadcastScheduleAsync( Guid broadcastId, DateTime scheduleFor, CancellationToken cancellationToken = default )
    {
        var req = new BroadcastScheduleRequest()
        {
            MomentSchedule = scheduleFor,
        };

        var path = $"/broadcasts/{broadcastId}/send";
        var resp = await _http.PostAsJsonAsync( path, req, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse<List<Broadcast>>> BroadcastListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/broadcasts";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<Broadcast>, List<Broadcast>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <inheritdoc/>
    public async Task<ResendResponse> BroadcastDeleteAsync( Guid broadcastId, CancellationToken cancellationToken = default )
    {
        var path = $"/broadcasts/{broadcastId}";
        var resp = await _http.DeleteAsync( path, cancellationToken );

        return await Handle( resp, cancellationToken );
    }


    /// <summary />
    private async Task<ResendResponse> Handle( HttpResponseMessage resp, CancellationToken cancellationToken )
    {
        /*
         * Following block is the same as Habdle<T1, T2>, but the response isn't <T2>.
         */
        if ( resp.IsSuccessStatusCode == false )
        {
            ErrorResponse? err;

            try
            {
                err = await resp.Content.ReadFromJsonAsync<ErrorResponse>( cancellationToken );
            }
            catch ( Exception iex )
            {
                ResendException oex = new ResendException( HttpStatusCode.UnprocessableContent, ErrorType.Deserialization, "Failed deserializing error response", iex );

                if ( _throw == true )
                    throw oex;

                return new ResendResponse( oex );
            }

            ResendException ex;

            if ( err == null )
                ex = new ResendException( resp.StatusCode, ErrorType.MissingResponse, "Missing error response" );
            else
                ex = new ResendException( err.StatusCode, err.ErrorType, err.Message );

            if ( _throw == true )
                throw ex;

            return new ResendResponse( ex );
        }


        /*
         * 
         */
        return new ResendResponse();
    }


    /// <summary />
    private async Task<ResendResponse<T2>> Handle<T1, T2>( HttpResponseMessage resp,
        Func<T1, T2> map,
        CancellationToken cancellationToken )
    {
        /*
         * 
         */
        if ( resp.IsSuccessStatusCode == false )
        {
            ErrorResponse? err;

            try
            {
                err = await resp.Content.ReadFromJsonAsync<ErrorResponse>( cancellationToken );
            }
            catch ( Exception iex )
            {
                ResendException oex = new ResendException( HttpStatusCode.UnprocessableContent, ErrorType.Deserialization, "Failed deserializing error response", iex );

                if ( _throw == true )
                    throw oex;

                return new ResendResponse<T2>( oex );
            }

            ResendException ex;

            if ( err == null )
                ex = new ResendException( resp.StatusCode, ErrorType.MissingResponse, "Missing error response" );
            else
                ex = new ResendException( err.StatusCode, err.ErrorType, err.Message );

            if ( _throw == true )
                throw ex;

            return new ResendResponse<T2>( ex );
        }


        /*
         * 
         */
        T1? obj;

        try
        {
            obj = await resp.Content.ReadFromJsonAsync<T1>( cancellationToken );
        }
        catch ( Exception ex )
        {
            ResendException oex = new ResendException( HttpStatusCode.UnprocessableContent, ErrorType.Deserialization, "Failed deserializing response", ex );

            if ( _throw == true )
                throw oex;

            return new ResendResponse<T2>( oex );
        }


        /*
         * 
         */
        if ( obj == null )
        {
            var ex = new ResendException( resp.StatusCode, ErrorType.MissingResponse, "Missing response" );

            if ( _throw )
                throw ex;

            return new ResendResponse<T2>( ex );
        }


        /*
         * Map T1 --> T2
         */
        T2 res;

        try
        {
            res = map( obj );
        }
        catch ( Exception ex )
        {
            var oex = new ResendException( resp.StatusCode, ErrorType.MissingResponse, "Failed to map response", ex );

            if ( _throw )
                throw oex;

            return new ResendResponse<T2>( oex );
        }


        /*
         * Ok
         */
        return new ResendResponse<T2>( res );
    }
}
