using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// List of email addresses.
/// </summary>
[JsonConverter( typeof( EmailAddressListConverter ) )]
public class EmailAddressList : List<string>
{
    /// <summary />
    public EmailAddressList()
    {
    }


    /// <summary />
    public static implicit operator EmailAddressList( string email )
    {
        var list = new EmailAddressList();
        list.Add( email );

        return list;
    }
}
