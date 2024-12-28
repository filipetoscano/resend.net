using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary />
public class ErrorResponse
{
    /// <summary />
    [JsonPropertyName( "statusCode" )]
    public int StatusCode { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public ErrorType ErrorType { get; set; }

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = "";
}