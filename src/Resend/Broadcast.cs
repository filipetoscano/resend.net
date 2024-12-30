using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Resend;

/// <summary />
public class Broadcast
{
    /// <summary>
    /// Broadcast identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    public Guid Id { get; set; }

    /// <summary>
    /// Display name of the broadcast. Only used for internal reference.
    /// </summary>
    [JsonPropertyName( "name" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Audience identifier.
    /// </summary>
    [JsonPropertyName( "audience_id" )]
    public Guid AudienceId { get; set; }

    /// <summary>
    /// Status.
    /// </summary>
    [JsonPropertyName( "status" )]
    public BroadcastStatus Status { get; set; }

    /// <summary>
    /// Moment in which the Broadcast was created.
    /// </summary>
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime MomentCreated { get; set; }

    /// <summary>
    /// Moment in which the Broadcast is/was scheduled for.
    /// </summary>
    [JsonPropertyName( "scheduled_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime? MomentScheduled { get; set; }

    /// <summary>
    /// Moment in which the Broadcast was sent.
    /// </summary>
    [JsonPropertyName( "sent_at" )]
    [JsonConverter( typeof( JsonUtcDateTimeConverter ) )]
    public DateTime? MomentSent { get; set; }
}