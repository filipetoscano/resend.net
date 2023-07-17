using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Resend.Net;

public class ResendClient
{
    public ResendClient( IOptions<ResendClientOptions> options, HttpClient httpClient )
    {
        var opt = options.Value;

        httpClient.BaseAddress = new Uri( opt.ApiUrl );
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", opt.ApiKey );
    }


    public Task<string> EmailSendAsync( EmailMessage email )
    {
        throw new NotImplementedException();
    }


    public Task<EmailMessage> EmailRetrieveAsync( string emailId )
    {
        throw new NotImplementedException();
    }


    public Task<Domain> DomainAddAsync( string domainName, DeliveryRegion? region )
    {
        throw new NotImplementedException();
    }


    public Task<Domain> DomainRetrieveAsync( string domainId )
    {
        throw new NotImplementedException();
    }


    public Task DomainVerifyAsync( string domainId )
    {
        throw new NotImplementedException();
    }


    public Task<List<Domain>> DomainListAsync()
    {
        throw new NotImplementedException();
    }


    public Task DomainDeleteAsync( string domainId )
    {
        throw new NotImplementedException();
    }


    public Task<ApiKey> ApiKeyCreateAsync( string keyName, Permission? permission, string? domainId )
    {
        throw new NotImplementedException();
    }


    public Task<List<ApiKey>> ApiKeyListAsync()
    {
        throw new NotImplementedException();
    }


    public Task ApiKeyRemove( string apiKeyId )
    {
        throw new NotImplementedException();
    }
}
