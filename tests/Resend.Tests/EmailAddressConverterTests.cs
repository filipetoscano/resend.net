using System.Text.Json;

namespace Resend.Tests;

/// <summary />
public class EmailAddressConverterTests
{
    /// <summary />
    [Fact]
    public void EmailOnly()
    {
        var src = new EmailAddress();
        src.Email = "dev@example.com";

        var json = JsonSerializer.Serialize( src );
        Assert.Equal( "\"" + src.Email + "\"", json );

        var tgt = JsonSerializer.Deserialize<EmailAddress>( json );

        Assert.NotNull( tgt );
        Assert.Null( tgt.FriendlyName );
        Assert.NotNull( tgt.Email );
        Assert.Equal( src.Email, tgt.Email );
    }


    /// <summary />
    [Fact]
    public void FriendlyName()
    {
        var src = new EmailAddress();
        src.Email = "dev@example.com";
        src.FriendlyName = "Very Friendly";

        var json = JsonSerializer.Serialize( src );
        var tgt = JsonSerializer.Deserialize<EmailAddress>( json );

        Assert.NotNull( tgt );
        Assert.NotNull( tgt.Email );
        Assert.NotNull( tgt.FriendlyName );
        Assert.Equal( src.Email, tgt.Email );
        Assert.Equal( src.FriendlyName, tgt.FriendlyName );
    }


    /// <summary />
    [Fact]
    public void UnicodeFriendly()
    {
        var src = new EmailAddress();
        src.Email = "dev@example.com";
        src.FriendlyName = "☠️";

        var json = JsonSerializer.Serialize( src );
        var tgt = JsonSerializer.Deserialize<EmailAddress>( json );

        Assert.NotNull( tgt );
        Assert.NotNull( tgt.Email );
        Assert.NotNull( tgt.FriendlyName );
        Assert.Equal( src.Email, tgt.Email );
        Assert.Equal( src.FriendlyName, tgt.FriendlyName );
    }
}
