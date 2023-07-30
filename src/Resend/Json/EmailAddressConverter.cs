using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Resend;

/// <summary />
public class EmailAddressConverter : JsonConverter<EmailAddress>
{
    private static readonly Regex _fn = new Regex( "^(?<displayName>.*) <(?<email>.*)>$" );

    /// <inheritdoc />
    public override EmailAddress? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.String )
            throw new JsonException( $"EA001: Expected String, instead found '{reader.TokenType}'" );

        var addr = reader.GetString()!;


        /*
         * 
         */
        string email;
        string? displayName = null;

        var m = _fn.Match( addr );

        if ( m.Success == true )
        {
            email = m.Groups[ "email" ].Value;
            displayName = m.Groups[ "displayName" ].Value;
        }
        else
        {
            email = addr;
        }


        /*
         * 
         */
        return new EmailAddress()
        {
            Email = email,
            DisplayName = displayName,
        };
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, EmailAddress value, JsonSerializerOptions options )
    {
        string addr;

        if ( value.DisplayName == null )
            addr = value.Email;
        else
            addr = $"{value.DisplayName} <{value.Email}>";

        writer.WriteStringValue( addr );
    }
}
