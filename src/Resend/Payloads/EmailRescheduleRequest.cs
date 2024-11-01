using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary />
public class EmailRescheduleRequest
{
    /// <summary />
    [JsonPropertyName( "scheduledAt" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentSchedule { get; set; }
}
