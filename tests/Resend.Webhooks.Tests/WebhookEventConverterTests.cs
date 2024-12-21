using System;
using System.Text.Json;

namespace Resend.Webhooks.Tests;

/// <summary />
public class WebhookEventConverterTests
{
    /// <summary />
    [Fact]
    public void EmailEventRoundtrip()
    {
        var utcNow = DateTime.UtcNow;
        utcNow = new DateTime(
            utcNow.Ticks - ( utcNow.Ticks % TimeSpan.TicksPerSecond ),
            utcNow.Kind
        );


        /*
         * 
         */
        var expectedEmail = new EmailEventData();
        expectedEmail.Subject = "Test Roundtrip";
        expectedEmail.MomentCreated = utcNow;

        var expected = new WebhookEvent();
        expected.EventType = Resend.WebhookEvent.EmailSent;
        expected.MomentCreated = utcNow;
        expected.Data = expectedEmail;

        var json = JsonSerializer.Serialize( expected );
        var actual = JsonSerializer.Deserialize<WebhookEvent>( json );


        /*
         *
         */
        Assert.NotNull( actual );
        Assert.Equal( expected.EventType, actual.EventType );
        Assert.Equal( expected.MomentCreated, actual.MomentCreated );
        Assert.Equal( expected.Data.GetType(), actual.Data.GetType() );

        var actualEmail = expected.DataAs<EmailEventData>();

        Assert.Equal( expectedEmail.Subject, actualEmail.Subject );
        Assert.Equal( expectedEmail.MomentCreated, actualEmail.MomentCreated );
    }


    /// <summary />
    [Fact]
    public void ContactEventRoundtrip()
    {
        var utcNow = DateTime.UtcNow;
        utcNow = new DateTime(
            utcNow.Ticks - ( utcNow.Ticks % TimeSpan.TicksPerSecond ),
            utcNow.Kind
        );


        /*
         * 
         */
        var expectedContact = new ContactEventData();
        expectedContact.ContactId = Guid.NewGuid();
        expectedContact.Email = "test@example.com";
        expectedContact.MomentCreated = utcNow;

        var expected = new WebhookEvent();
        expected.EventType = Resend.WebhookEvent.ContactCreated;
        expected.MomentCreated = utcNow;
        expected.Data = expectedContact;

        var json = JsonSerializer.Serialize( expected );
        var actual = JsonSerializer.Deserialize<WebhookEvent>( json );


        /*
         *
         */
        Assert.NotNull( actual );
        Assert.Equal( expected.EventType, actual.EventType );
        Assert.Equal( expected.MomentCreated, actual.MomentCreated );
        Assert.Equal( expected.Data.GetType(), actual.Data.GetType() );

        var actualContact = expected.DataAs<ContactEventData>();

        Assert.Equal( expectedContact.ContactId, actualContact.ContactId );
        Assert.Equal( expectedContact.Email, actualContact.Email );
        Assert.Equal( expectedContact.MomentCreated, actualContact.MomentCreated );
    }


    /// <summary />
    [Fact]
    public void DomainEventRoundtrip()
    {
        var utcNow = DateTime.UtcNow;
        utcNow = new DateTime(
            utcNow.Ticks - ( utcNow.Ticks % TimeSpan.TicksPerSecond ),
            utcNow.Kind
        );


        /*
         * 
         */
        var expectedDomain = new DomainEventData();
        expectedDomain.Id = Guid.NewGuid();
        expectedDomain.Name = "example.com";
        expectedDomain.MomentCreated = utcNow;

        var expected = new WebhookEvent();
        expected.EventType = Resend.WebhookEvent.DomainCreated;
        expected.MomentCreated = utcNow;
        expected.Data = expectedDomain;

        var json = JsonSerializer.Serialize( expected );
        var actual = JsonSerializer.Deserialize<WebhookEvent>( json );


        /*
         *
         */
        Assert.NotNull( actual );
        Assert.Equal( expected.EventType, actual.EventType );
        Assert.Equal( expected.MomentCreated, actual.MomentCreated );
        Assert.Equal( expected.Data.GetType(), actual.Data.GetType() );

        var actualDomain = expected.DataAs<DomainEventData>();

        Assert.Equal( expectedDomain.Id, actualDomain.Id );
        Assert.Equal( expectedDomain.Name, actualDomain.Name );
        Assert.Equal( expectedDomain.MomentCreated, actualDomain.MomentCreated );
    }
}
