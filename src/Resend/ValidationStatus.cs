using System.Text.Json.Serialization;

namespace Resend;

/// <summary />
/// <see href="https://resend.com/docs/dashboard/domains/introduction#understand-a-domain-status" />
/// <see href="https://github.com/resend/resend-node/blob/canary/src/domains/interfaces/domain.ts" />
[JsonConverter( typeof( JsonStringEnumValueConverter<ValidationStatus> ) )]
public enum ValidationStatus
{
    /// <summary>
    /// Domain has been created, but validation hasn't been explicitly requested.
    /// </summary>
    /// <remarks>
    /// Validation can be initiated by calling the <see cref="IResend.DomainVerifyAsync(Guid, CancellationToken)"/>
    /// method.
    /// </remarks>
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
    /// Validation has failed: Resend was unable to detect necessary DNS
    /// records within 72h.
    /// </summary>
    [JsonStringValue( "failed" )]
    Failed,

    /// <summary>
    /// Previously verified domain no longer has necessary DNS records.
    /// </summary>
    /// <remarks>
    /// For a previously verified domain, Resend will periodically check for the DNS
    /// record required for verification. If at some point, Resend is unable to detect
    /// the record, the status would change to “<see cref="TemporaryFailure" />”. Resend will
    /// recheck for the DNS record for 72 hours, and if it’s unable to detect the
    /// record, the domain status would change to “<see cref="Failed" />”. If it’s able to detect
    /// the record, the domain status would change to “<see cref="Verified"/>”.
    /// </remarks>
    [JsonStringValue( "temporary_failure" )]
    TemporaryFailure,

    /// <summary>
    /// Domain is successfully verified for sending in Resend.
    /// </summary>
    [JsonStringValue( "verified" )]
    Verified,
}
