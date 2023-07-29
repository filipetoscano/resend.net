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
        Assert.Null( tgt.DisplayName );
        Assert.NotNull( tgt.Email );
        Assert.Equal( src.Email, tgt.Email );
    }


    /// <summary />
    [Fact]
    public void FriendlyName()
    {
        var src = new EmailAddress();
        src.Email = "dev@example.com";
        src.DisplayName = "Very Friendly";

        var json = JsonSerializer.Serialize( src );
        var tgt = JsonSerializer.Deserialize<EmailAddress>( json );

        Assert.NotNull( tgt );
        Assert.NotNull( tgt.Email );
        Assert.NotNull( tgt.DisplayName );
        Assert.Equal( src.Email, tgt.Email );
        Assert.Equal( src.DisplayName, tgt.DisplayName );
    }


    /// <summary />
    [Fact]
    public void UnicodeFriendly()
    {
        var src = new EmailAddress();
        src.Email = "dev@example.com";
        src.DisplayName = "☠️";

        var json = JsonSerializer.Serialize( src );
        var tgt = JsonSerializer.Deserialize<EmailAddress>( json );

        Assert.NotNull( tgt );
        Assert.NotNull( tgt.Email );
        Assert.NotNull( tgt.DisplayName );
        Assert.Equal( src.Email, tgt.Email );
        Assert.Equal( src.DisplayName, tgt.DisplayName );
    }
}
