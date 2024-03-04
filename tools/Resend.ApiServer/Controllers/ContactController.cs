using Microsoft.AspNetCore.Mvc;
using Resend.Payloads;

namespace Resend.ApiServer.Controllers;

/// <summary />
[ApiController]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;


    /// <summary />
    public ContactController( ILogger<ContactController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpPost]
    [Route( "audiences/{audienceId}/contacts" )]
    public ContactData ContactCreate( [FromRoute] Guid audienceId, [FromBody] ContactCreateRequest message )
    {
        _logger.LogDebug( "ContactCreate" );

        return new ContactData()
        {
            Id = Guid.NewGuid()
        };
    }


    /// <summary />
    [HttpGet]
    [Route( "audiences/{audienceId}/contacts/{contactId}" )]
    public Contact ContactRetrieve( [FromRoute] Guid audienceId, Guid contactId )
    {
        _logger.LogDebug( "ContactRetrieve" );

        return new Contact()
        {
            Id = contactId,
            Email = "email@test.com",
            FirstName = "Bob",
            LastName = "Test",
            Created = DateTime.UtcNow.AddDays( -1 ),
            Unsubscribed = true
        };
    }


    /// <summary />
    [HttpPatch]
    [Route( "audiences/{audienceId}/contacts/{contactId}" )]
    public ContactData ContactUpdate( [FromRoute] Guid audienceId, Guid contactId, [FromBody] ContactCreateRequest message )
    {
        _logger.LogDebug( "ContactUpdate" );

        return new ContactData()
        {
            Id = Guid.NewGuid()
        };
    }


    /// <summary />
    [HttpDelete]
    [Route( "audiences/{audienceId}/contacts/{contactId}" )]
    public ActionResult ContactDelete( [FromRoute] Guid audienceId, Guid? contactId )
    {
        _logger.LogDebug( "ContactDelete" );

        return Ok();
    }


    /// <summary />
    [HttpGet]
    [Route( "audiences/{audienceId}/contacts" )]
    public ListOf<Contact> ContactList( [FromRoute] Guid audienceId )
    {
        _logger.LogDebug( "ContactList" );

        var list = new List<Contact>();

        list.Add( new Contact()
        {
            Id = Guid.NewGuid(),
            Email = "test@mail.com",
            FirstName = "Bob",
            LastName = "Test",
            Created = DateTime.UtcNow,
            Unsubscribed = true
        } );

        list.Add( new Contact()
        {
            Id = Guid.NewGuid(),
            Email = "test2@mail.com",
            FirstName = "Carl",
            LastName = "Test",
            Created = DateTime.UtcNow,
            Unsubscribed = true
        } );

        return new ListOf<Contact>()
        {
            Data = list,
        };
    }
}
