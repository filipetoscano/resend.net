using Microsoft.AspNetCore.Mvc;
using Resend.Payloads;

namespace Resend.ApiServer.Controllers;

/// <summary />
[ApiController]
public class AudienceController : ControllerBase
{
    private readonly ILogger<AudienceController> _logger;


    /// <summary />
    public AudienceController( ILogger<AudienceController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpPost]
    [Route( "audiences" )]
    public AudienceData AudienceCreate( [FromBody] AudienceCreateRequest message )
    {
        _logger.LogDebug( "AudienceCreate" );

        return new AudienceData()
        {
            Id = Guid.NewGuid(),
            Name = message.Name
        };
    }

    /// <summary />
    [HttpGet]
    [Route( "audiences/{id}" )]
    public Audience AudienceRetrieve( [FromRoute] Guid id )
    {
        _logger.LogDebug( "AudienceRetrieve" );

        return new Audience()
        {
            Id = id,
            Name = "Audience Test",
            Created = DateTime.UtcNow.AddDays(-1)
        };
    }


    /// <summary />
    [HttpGet]
    [Route( "audiences" )]
    public ListOf<Audience> AudienceList()
    {
        _logger.LogDebug( "AudienceList" );

        var list = new List<Audience>();

        list.Add( new Audience()
        {
            Id = Guid.NewGuid(),
            Name = "My Audience 1",
            Created = DateTime.UtcNow,
        } );

        list.Add( new Audience()
        {
            Id = Guid.NewGuid(),
            Name = "My Audience 2",
            Created = DateTime.UtcNow,
        } );

        return new ListOf<Audience>()
        {
            Data = list,
        };
    }


    /// <summary />
    [HttpDelete]
    [Route( "audiences/{id}" )]
    public ActionResult AudienceDelete( [FromRoute] Guid id )
    {
        return Ok();
    }
}
