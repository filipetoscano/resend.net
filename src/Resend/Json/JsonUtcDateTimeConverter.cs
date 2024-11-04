using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Specifies the DateTime UTC value that is present in the JSON when serializing and deserializing.
/// </summary>
public class JsonUtcDateTimeConverter : JsonConverter<DateTime>
{
    /// <inheritdoc/>
    public override DateTime Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        /*
         * The API examples have the following values:
         * 2023-04-08T00:11:13.110779+00:00
         * 2023-04-26T20:21:26.347412+00:00
         */

        if ( reader.TokenType != JsonTokenType.String )
            throw new JsonException( $"Expected String when converting DateTime, found {reader.TokenType}" );

        var str = reader.GetString()!;
        DateTime value;

        try
        {
            // TODO: Consider exact parsing?

            value = DateTime.Parse( str );
        }
        catch ( FormatException ex )
        {
            throw new JsonException( $"Value '{str}' is not valid", ex );
        }


        /*
         * Ensure UTC
         */
        if ( value.Kind == DateTimeKind.Utc )
            return value;

        return value.ToUniversalTime();
    }


    /// <inheritdoc/>
    public override void Write( Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options )
    {
        writer.WriteStringValue( value.ToUniversalTime().ToString( "yyyy-MM-ddTHH:mm:ssZ" ) );
    }
}
