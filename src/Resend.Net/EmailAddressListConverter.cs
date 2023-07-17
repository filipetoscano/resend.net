using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend.Net;


/// <summary />
public class EmailAddressListConverter : JsonConverter<List<string>?>
{
    /// <inheritdoc />
    public override List<string>? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, List<string>? value, JsonSerializerOptions options )
    {
        if ( value == null )
            return;

        if ( value.Count == 0 )
            return;

        throw new NotImplementedException();
    }
}
