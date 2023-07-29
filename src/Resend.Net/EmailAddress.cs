using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
[JsonConverter( typeof( EmailAddressConverter ) )]
public class EmailAddress
{
    /// <summary />
    public string Email { get; set; } = default!;

    /// <summary />
    public string? FriendlyName { get; set; }


    /// <summary />
    public static implicit operator EmailAddress( string email ) => new EmailAddress() { Email = email };
}


/// <summary />
public class EmailAddressConverter : JsonConverter<EmailAddress>
{
    /// <inheritdoc />
    public override EmailAddress? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        var addr = reader.GetString();

        if ( addr == null )
            return null;


        /*
         * 
         */
        string email;
        string? friendlyName = null;

        if ( addr.EndsWith( ">" ) == true )
        {
            throw new NotImplementedException();
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
            FriendlyName = friendlyName,
        };
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, EmailAddress value, JsonSerializerOptions options )
    {
        string addr;

        if ( value.FriendlyName == null )
            addr = value.Email;
        else
            addr = $"{value.FriendlyName} <{value.Email}>";

        writer.WriteStringValue( addr );
    }
}
