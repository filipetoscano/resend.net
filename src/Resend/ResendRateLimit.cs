namespace Resend;

/// <summary />
public class ResendRateLimit
{
    /// <summary>
    /// Maximum number of requests allowed within a window.
    /// </summary>
    public int? Limit { get; internal set; }

    /// <summary>
    /// How many requests you have left within the current window.
    /// </summary>
    public int? Remaining { get; internal set; }

    /// <summary>
    /// How many seconds until the limits are reset.
    /// </summary>
    public int? Reset { get; internal set; }

    /// <summary>
    /// How many seconds you should wait before making a follow-up request.
    /// </summary>
    public int? RetryAfter { get; internal set; }

    /// <summary />
    public string? Policy { get; internal set; }
}