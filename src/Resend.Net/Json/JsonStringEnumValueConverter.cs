using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
public class JsonStringEnumValueConverter<T> : JsonConverter<T>
    where T : struct, Enum
{
    private readonly Dictionary<T, string> _fwd;
    private readonly Dictionary<string, T> _rev;


    /// <summary />
    public JsonStringEnumValueConverter()
    {
        var tt = typeof( T );
        
        var names = tt.GetEnumNames();
        var values = tt.GetEnumValues();

        var fwd = new Dictionary<T, string>( names.Length );
        var rev = new Dictionary<string, T>( names.Length );

        for ( var i = 0; i < names.Length; i++ )
        {
            var name = names[i];
            var field = tt.GetField( name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static )!;

            var str = field.GetCustomAttribute<JsonStringValueAttribute>()?.Value ?? name;
            var val = (T) values.GetValue( i )!;

            fwd.Add( val, str );
            rev.Add( str, val );
        }

        _fwd = fwd;
        _rev = rev;
    }


    /// <inheritdoc />
    public override T Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.String )
            throw new InvalidOperationException( $"Expected String, instead {reader.TokenType}" );

        var json = reader.GetString()!;


        /*
         * 
         */
        if ( _rev.TryGetValue( json, out var rev ) == false )
            throw new InvalidOperationException( $"Invalid value: '{json}'" );

        return rev;
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, T value, JsonSerializerOptions options )
    {
        var str = _fwd[ value ];

        writer.WriteStringValue( str );
    }
}
