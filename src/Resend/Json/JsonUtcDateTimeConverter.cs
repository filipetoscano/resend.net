using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend.Json;

/// <summary>
/// Specifies the DateTime UTC value that is present in the JSON when serializing and deserializing.
/// </summary>
public class JsonUtcDateTimeConverter : JsonConverter<DateTime>
{
    /// <inheritdoc/>
    public override DateTime Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        var date = DateTime.Parse( reader.GetString() );
        return DateTime.SpecifyKind( date, DateTimeKind.Utc );
    }

    
    /// <inheritdoc/>
    public override void Write( Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options )
    {
        writer.WriteStringValue( value.ToUniversalTime().ToString( "yyyy-MM-ddTHH:mm:ssZ" ) );
    }
}

