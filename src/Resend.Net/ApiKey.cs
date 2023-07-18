using System.Text.Json.Serialization;

namespace Resend.Net;


/// <summary />
public class ApiKeyData
{
}


/// <summary />
public class ApiKey
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "created_at" )]
    public DateTime MomentCreated { get; set; }
}
