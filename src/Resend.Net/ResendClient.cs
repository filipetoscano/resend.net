using Microsoft.Extensions.Options;
using Resend.Net.Payloads;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;

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
    public Task<Domain> DomainAddAsync( string domainName, DeliveryRegion? region )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public Task<Domain> DomainRetrieveAsync( string domainId )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public Task DomainVerifyAsync( string domainId )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public Task<List<Domain>> DomainListAsync()
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public Task DomainDeleteAsync( string domainId )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public Task<ApiKey> ApiKeyCreateAsync( string keyName, Permission? permission, string? domainId )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public async Task<List<ApiKey>> ApiKeyListAsync( CancellationToken cancellationToken = default )
    {
        var path = $"/api-keys";
        var resp = await _http.GetAsync( path, HttpCompletionOption.ResponseContentRead, cancellationToken );

        resp.EnsureSuccessStatusCode();

        var obj = await resp.Content.ReadFromJsonAsync<ApiKeyList>( cancellationToken: cancellationToken );

        if ( obj == null )
            throw new InvalidOperationException( "Received null response" );

        return obj.data;
    }


    /// <inheritdoc />
    public Task ApiKeyRemove( string apiKeyId )
    {
        throw new NotImplementedException();
    }
}
