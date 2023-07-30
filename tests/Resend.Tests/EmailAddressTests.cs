using System.Text.Json;

namespace Resend.Tests;

/// <summary />
public class EmailAddressTests
{
    /// <summary />
    [Fact]
    public void Operator()
    {
        EmailAddress src = "dev@example.com";

        var json = JsonSerializer.Serialize( src );
        Assert.Equal( "\"" + src.Email + "\"", json );

        var tgt = JsonSerializer.Deserialize<EmailAddress>( json );

        Assert.NotNull( tgt );
        Assert.Null( tgt.DisplayName );
        Assert.NotNull( tgt.Email );
        Assert.Equal( src.Email, tgt.Email );
    }
}
