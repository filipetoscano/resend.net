using Microsoft.AspNetCore.Http;

namespace Resend.Webhooks;

/// <summary />
public interface IWebhookHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task<IResult> HandleValid( WebhookContext context );


    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task<IResult> HandleInvalid( WebhookContext context );
}