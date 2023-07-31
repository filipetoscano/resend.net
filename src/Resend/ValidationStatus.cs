using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
[JsonConverter( typeof( JsonStringEnumValueConverter<ValidationStatus> ) )]
public enum ValidationStatus
{
    /// <summary>
    /// Validation has not started.
    /// </summary>
    [JsonStringValue( "not_started" )]
    NotStarted,

    /// <summary>
    /// Validation has been started and is currently executing.
    /// </summary>
    /// <remarks>
    /// May take up to 72h to conclude.
    /// </remarks>
    [JsonStringValue( "pending" )]
    Pending,

    /// <summary>
    /// Validation has failed.
    /// </summary>
    [JsonStringValue( "failed" )]
    Failed,
}
