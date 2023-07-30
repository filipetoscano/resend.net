using System.Text.Json;

namespace Resend.Tests;

/// <summary />
public class EmailAddressListConverterTests
{
    /// <summary />
    [Fact]
    public void Operator()
    {
        const string Email = "dev@example.com";
        EmailAddressList list = Email;

        Assert.NotNull( list );
        Assert.Single( list );
        Assert.Equal( Email, list.Single() );
    }


    /// <summary />
    [Fact]
    public void DeserializeSingle()
    {
        const string Email = "dev@example.com";
        var json = "\"" + Email + "\"";

        var list = JsonSerializer.Deserialize<EmailAddressList>( json );

        Assert.NotNull( list );
        Assert.Single( list );
        Assert.Equal( Email, list.Single() );
    }


    /// <summary />
    [Fact]
    public void RoundtripTwo()
    {
        var src = new EmailAddressList();
        src.Add( "one@example.com" );
        src.Add( "two@example.com" );

        var json = JsonSerializer.Serialize( src );

        var tgt = JsonSerializer.Deserialize<EmailAddressList>( json );

        Assert.NotNull( tgt );
        Assert.Equal( 2, tgt.Count );
        Assert.Equal( src[ 0 ], tgt[ 0 ] );
        Assert.Equal( src[ 1 ], tgt[ 1 ] );
    }


    /// <summary />
    [Fact]
    public void FromNumber()
    {
        var json = "1";

        Action act = () => JsonSerializer.Deserialize<EmailAddressList>( json );

        var ex = Assert.Throws<JsonException>( act );
        Assert.NotNull( ex.Path );
        Assert.NotNull( ex.LineNumber );
        Assert.NotNull( ex.BytePositionInLine );
        Assert.StartsWith( "EL001:", ex.Message );
    }


    /// <summary />
    [Fact]
    public void WithNumber()
    {
        var json = "[1,2]";

        Action act = () => JsonSerializer.Deserialize<EmailAddressList>( json );

        var ex = Assert.Throws<JsonException>( act );
        Assert.NotNull( ex.Path );
        Assert.NotNull( ex.LineNumber );
        Assert.NotNull( ex.BytePositionInLine );
        Assert.StartsWith( "EL002:", ex.Message );
    }
}