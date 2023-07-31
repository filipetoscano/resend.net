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
}
