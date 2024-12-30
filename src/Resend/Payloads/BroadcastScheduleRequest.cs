using System.Text.Json.Serialization;

namespace Resend.Payloads;

/// <summary />
public class BroadcastScheduleRequest
{
    /// <summary />
    [JsonPropertyName( "scheduled_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime? MomentSchedule { get; set; }
}
