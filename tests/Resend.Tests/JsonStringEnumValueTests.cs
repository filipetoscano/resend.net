using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend.Tests;

/// <summary />
public class JsonStringEnumValueTests
{
    /// <summary />
    [JsonConverter( typeof( JsonStringEnumValueConverter<TestEnum> ) )]
    public enum TestEnum
    {
        /// <summary />
        [JsonStringValue( "vee-one" )]
        ValueOne,

        /// <summary />
        [JsonStringValue( "ValueOne" )]
        WrongOne,

        /// <summary />
        ValueTwo,
    }


    /// <summary />
    [JsonConverter( typeof( JsonStringEnumValueConverter<OtherEnum> ) )]
    public enum OtherEnum
    {
        /// <summary />
        [JsonStringValue( "vee-one" )]
        V1,

        /// <summary />
        [JsonStringValue( "vee-two" )]
        V2,
    }


    /// <summary />
    [Fact]
    public void WithAttribute()
    {
        var src = TestEnum.ValueOne;

        var json = JsonSerializer.Serialize( src );
        Assert.Equal( "\"vee-one\"", json );

        var tgt = JsonSerializer.Deserialize<TestEnum>( json );
        Assert.Equal( TestEnum.ValueOne, tgt );
    }


    /// <summary />
    [Fact]
    public void WithoutAttribute()
    {
        var src = TestEnum.ValueTwo;

        var json = JsonSerializer.Serialize( src );
        Assert.Equal( "\"ValueTwo\"", json );

        var tgt = JsonSerializer.Deserialize<TestEnum>( json );
        Assert.Equal( TestEnum.ValueTwo, tgt );
    }


    /// <summary />
    [Fact]
    public void OtherAttribute()
    {
        var src = TestEnum.ValueOne;

        var json = JsonSerializer.Serialize( src );
        Assert.Equal( "\"vee-one\"", json );

        var tgt = JsonSerializer.Deserialize<OtherEnum>( json );
        Assert.Equal( OtherEnum.V1, tgt );
    }


    /// <summary />
    [Fact]
    public void FromNumber()
    {
        var json = "1";

        Action act = () => JsonSerializer.Deserialize<TestEnum>( json );

        var ex = Assert.Throws<JsonException>( act );
        Assert.NotNull( ex.Path );
        Assert.NotNull( ex.LineNumber );
        Assert.NotNull( ex.BytePositionInLine );
        Assert.StartsWith( "SE001:", ex.Message );
    }


    /// <summary />
    [Fact]
    public void FromInvalid()
    {
        var json = "\"xpto\"";

        Action act = () => JsonSerializer.Deserialize<TestEnum>( json );

        var ex = Assert.Throws<JsonException>( act );
        Assert.NotNull( ex.Path );
        Assert.NotNull( ex.LineNumber );
        Assert.NotNull( ex.BytePositionInLine );
        Assert.StartsWith( "SE002:", ex.Message );
    }
}
