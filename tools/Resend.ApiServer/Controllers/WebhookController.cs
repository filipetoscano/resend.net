using Microsoft.AspNetCore.Mvc;
using Resend.Payloads;

namespace Resend.ApiServer.Controllers;

/// <summary />
[ApiController]
public class WebhookController : ControllerBase
{
    private readonly ILogger<WebhookController> _logger;


    /// <summary />
    public WebhookController( ILogger<WebhookController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpGet]
    [Route( "webhooks" )]
    public ListOf<Webhook> WebhookList()
    {
        _logger.LogDebug( "WebhookList" );

        return new ListOf<Webhook>()
        {
            Data = new List<Webhook>()
            {
                new Webhook()
                {
                    Id = Guid.NewGuid(),
                },
                new Webhook()
                {
                    Id = Guid.NewGuid(),
                }
            },
        };
    }
}
