using Microsoft.AspNetCore.Mvc;
using Resend.Payloads;

namespace Resend.ApiServer.Controllers;

/// <summary />
[ApiController]
public class EmailController : ControllerBase
{
    private readonly ILogger<EmailController> _logger;


    /// <summary />
    public EmailController( ILogger<EmailController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpPost]
    [Route( "emails" )]
    public ObjectId EmailSend( [FromBody] EmailMessage message )
    {
        _logger.LogDebug( "EmailSend" );

        return new ObjectId()
        {
            Object = "email",
            Id = Guid.NewGuid(),
        };
    }


    /// <summary />
    [HttpGet]
    [Route( "emails/{id}" )]
    public EmailReceipt EmailRetrieve( [FromRoute] Guid id )
    {
        _logger.LogDebug( "EmailRetrieve" );

        return new EmailReceipt()
        {
            Id = id,
            Subject = "Demo",
            From = "from@example.com",
            To = "to@example.com",
            HtmlBody = "This is HTML!",
        };
    }


    /// <summary />
    [HttpPost]
    [Route( "emails/batch" )]
    public IEnumerable<ObjectId> EmailBatch( [FromBody] List<EmailMessage> messages )
    {
        _logger.LogDebug( "EmailBatch" );

        return messages.Select( x => new ObjectId()
        {
            Object = "email",
            Id = Guid.NewGuid(),
        } );
    }


    /// <summary />
    [HttpPatch]
    [Route( "emails/{id}" )]
    public ObjectId EmailReschedule( [FromRoute] Guid emailId, [FromBody] EmailRescheduleRequest request )
    {
        _logger.LogDebug( "EmailReschedule" );

        return new ObjectId()
        {
            Object = "email",
            Id = emailId,
        };
    }


    /// <summary />
    [HttpPost]
    [Route( "emails/{id}/cancel" )]
    public ObjectId EmailCancel( [FromRoute] Guid emailId )
    {
        _logger.LogDebug( "EmailCancel" );

        return new ObjectId()
        {
            Object = "email",
            Id = emailId,
        };
    }
}
