using Microsoft.AspNetCore.Mvc;

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
}
