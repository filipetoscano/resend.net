using Microsoft.AspNetCore.Mvc;
using Resend.Payloads;
using Resend.Webhooks;

namespace Resend.ApiServer.Controllers;

/// <summary />
[ApiController]
public class WebhookSinkController : ControllerBase
{
    private readonly ILogger<WebhookSinkController> _logger;


    /// <summary />
    public WebhookSinkController( ILogger<WebhookSinkController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpPost]
    [Route( "webhook/sink" )]
    public ActionResult WebhookSink( [FromBody] WebhookEvent @event )
    {


        return Ok();
    }
}
