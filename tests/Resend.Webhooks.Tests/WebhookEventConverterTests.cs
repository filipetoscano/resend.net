using System.Text.Json;

namespace Resend.Webhooks.Tests;

/// <summary />
public class WebhookEventConverterTests
{
    /// <summary />
    [Fact]
    public void EmailEventRoundtrip()
    {
        var expectedEmail = new EmailEventData();
        expectedEmail.Subject = "Test Roundtrip";
        expectedEmail.MomentCreated = DateTime.UtcNow;

        var expected = new WebhookEvent();
        expected.EventType = Resend.WebhookEvent.EmailSent;
        expected.MomentCreated = DateTime.UtcNow;
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
}
