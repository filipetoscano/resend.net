using Microsoft.AspNetCore.Mvc;
using Resend.Webhooks;

namespace Resend.ApiServer.Controllers;

/// <summary />
[ApiController]
public class WebhookSinkController : ControllerBase
{
    private readonly ILogger<WebhookSinkController> _logger;
    private readonly WebhookValidator _validator;


    /// <summary />
    public WebhookSinkController( ILogger<WebhookSinkController> logger, WebhookValidator validator )
    {
        _logger = logger;
        _validator = validator;
    }


    /// <summary />
    [HttpPost]
    [Route( "webhook/sink" )]
    public ActionResult WebhookSink( [FromBody] Webhooks.WebhookEvent @event )
    {
        /*
         * 
         */
        _logger.LogInformation( "Received {Category}: {EventType}", @event.EventType.Category(), @event.EventType );

        switch ( @event.EventType.Category() )
        {
            case WebhookEventTypeCategory.Email:
                var eed = @event.DataAs<EmailEventData>();

                _logger.LogDebug( "Email {EmailId}: {Subject}", eed.EmailId, eed.Subject );
                break;

            case WebhookEventTypeCategory.Domain:
                var ded = @event.DataAs<DomainEventData>();

                _logger.LogDebug( "Domain {DomainId}: {Name}", ded.Id, ded.Name );
                break;

            case WebhookEventTypeCategory.Contact:
                var ced = @event.DataAs<ContactEventData>();

                _logger.LogDebug( "Contact {ContactId}: {Email}", ced.ContactId, ced.Email );
                break;
        }


        /*
         * 
         */
        var vs = _validator.Validate( this.Request );

        if ( vs.IsValid == false )
        {
            _logger.LogError( "Invalid: {ErrorCode}: {Message}", vs.Exception?.ErrorCode, vs.Exception?.Message );
            return BadRequest();
        }


        return Ok();
    }
}