using Microsoft.Extensions.Options;
using Resend.Net.Payloads;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Resend.Net;

public class ResendClient : IResend
{
    private readonly HttpClient _http;


    public ResendClient( IOptions<ResendClientOptions> options, HttpClient httpClient )
    {
        var opt = options.Value;

        httpClient.BaseAddress = new Uri( opt.ApiUrl );
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", opt.ApiKey );

        _http = httpClient;
    }


    /// <inheritdoc />
    public async Task<Guid> EmailSendAsync( EmailMessage email, CancellationToken cancellationToken = default )
    {
        var resp = await _http.PostAsJsonAsync( "/emails", email, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ObjectId>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return obj.Id;
    }


    /// <inheritdoc />
    public async Task<EmailReceipt> EmailRetrieveAsync( Guid emailId, CancellationToken cancellationToken = default )
    {
        var path = $"/emails/{emailId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<EmailReceipt>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return obj;
    }


    /// <inheritdoc />
    public async Task<Domain> DomainAddAsync( string domainName, DeliveryRegion? region, CancellationToken cancellationToken = default )
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

        return obj;
    }


    /// <inheritdoc />
    public async Task<Domain> DomainRetrieveAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<Domain>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return obj;
    }


    /// <inheritdoc />
    public async Task DomainVerifyAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}/verify";
        var content = new StringContent( "" );

        var resp = await _http.PostAsync( path, content, cancellationToken );

        resp.EnsureSuccessStatusCode();
    }


    /// <inheritdoc />
    public async Task<List<Domain>> DomainListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/domains";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ListOf<Domain>>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return obj.Data;
    }


    /// <inheritdoc />
    public async Task DomainDeleteAsync( Guid domainId, CancellationToken cancellationToken = default )
    {
        var path = $"/domains/{domainId}";

        var resp = await _http.DeleteAsync( path, cancellationToken );

        resp.EnsureSuccessStatusCode();
    }


    /// <inheritdoc />
    public async Task<ApiKeyData> ApiKeyCreateAsync( string keyName, Permission? permission, Guid? domainId, CancellationToken cancellationToken = default )
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

        return obj;
    }


    /// <inheritdoc />
    public async Task<List<ApiKey>> ApiKeyListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/api-keys";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ListOf<ApiKey>>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return obj.Data;
    }


    /// <inheritdoc />
    public async Task ApiKeyDelete( Guid apiKeyId, CancellationToken cancellationToken = default )
    {
        var path = $"/api-keys/{apiKeyId}";

        var resp = await _http.DeleteAsync( path, cancellationToken );

        resp.EnsureSuccessStatusCode();
    }
}
