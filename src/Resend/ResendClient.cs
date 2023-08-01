using Microsoft.Extensions.Options;
using Resend.Payloads;
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
         * Ask for JSON responses. Not necessar atm, since Resend always/only
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

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ObjectId>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return new ResendResponse<Guid>( obj.Id );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<EmailReceipt>> EmailRetrieveAsync( Guid emailId, CancellationToken cancellationToken = default )
    {
        var path = $"/emails/{emailId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<EmailReceipt>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return new ResendResponse<EmailReceipt>( obj );
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

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<Domain>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return new ResendResponse<Domain>( obj );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<Domain>> DomainRetrieveAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<Domain>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return new ResendResponse<Domain>( obj );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> DomainVerifyAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}/verify";
        var content = new StringContent( "" );

        var resp = await _http.PostAsync( path, content, cancellationToken );

        resp.EnsureSuccessStatusCode();

        return new ResendResponse();
    }


    /// <inheritdoc />
    public async Task<ResendResponse<List<Domain>>> DomainListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/domains";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ListOf<Domain>>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return new ResendResponse<List<Domain>>( obj.Data );
    }


    /// <inheritdoc />
    public async Task<ResendResponse> DomainDeleteAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";

        var resp = await _http.DeleteAsync( path, cancellationToken );

        resp.EnsureSuccessStatusCode();

        return new ResendResponse();
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

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ApiKeyData>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return new ResendResponse<ApiKeyData>( obj );
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

        return Handle( resp );
    }


    /// <inheritdoc />
    public async Task<ResendResponse<List<Webhook>>> WebhookListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/webhooks";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        return await Handle<ListOf<Webhook>, List<Webhook>>( resp, ( x ) => x.Data, cancellationToken );
    }


    /// <summary />
    private ResendResponse Handle( HttpResponseMessage resp )
    {
        /*
         * 
         */
        if ( resp.IsSuccessStatusCode == false )
        {
            if ( _throw == true )
                resp.EnsureSuccessStatusCode();

            return new ResendResponse( resp.StatusCode );
        }

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
            if ( _throw == true )
                resp.EnsureSuccessStatusCode();

            return new ResendResponse<T2>( resp.StatusCode );
        }


        /*
         * 
         */
        T1? obj;

        try
        {
            obj = await resp.Content.ReadFromJsonAsync<T1>( cancellationToken: cancellationToken );
        }
        catch ( Exception ex )
        {
            if ( _throw == true )
                throw;

            return new ResendResponse<T2>( ex, $"RC001: Failed to deserialize response" );
        }


        /*
         * 
         */
        if ( obj == null )
        {
            if ( _throw )
                throw new InvalidOperationException( "RC002: Received null response" );

            return new ResendResponse<T2>( "RC002: Received null response" );
        }


        /*
         * 
         */
        T2 res;

        try
        {
            res = map( obj );
        }
        catch ( Exception ex )
        {
            if ( _throw )
                throw;

            return new ResendResponse<T2>( ex, $"RC003: Mapping from {typeof( T1 )} to {typeof( T2 )} failed" );
        }


        /*
         * 
         */
        return new ResendResponse<T2>( res );
    }
}
