namespace Resend.Tests;

/// <summary />
public class EmailAddressListTests
{
    /// <summary />
    [Fact]
    public void FromArray()
    {
        var array = new string[] { "a@example.com", "b@example.com" };
        var enumz = array.AsEnumerable();

        var list = EmailAddressList.From( enumz );

        Assert.NotNull( list );
        Assert.Equal( 2, list.Count );
        Assert.Equal( array[ 0 ], list[ 0 ] );
        Assert.Equal( array[ 1 ], list[ 1 ] );
    }


    /// <summary />
    [Fact]
    public void FromParams()
    {
        var list = EmailAddressList.From( "a@example.com", "b@example.com" );

        Assert.NotNull( list );
        Assert.Equal( 2, list.Count );
    }
}