namespace Resend.Net;

/// <summary />
public class ResendClientOptions
{
    /// <summary>
    /// Base URL for Resend API.
    /// </summary>
    /// <remarks>
    /// Default is `https://api.resend.com`.
    /// </remarks>
    public string ApiUrl { get; set; } = "https://api.resend.com";

    /// <summary>
    /// API key token.
    /// </summary>
    public string ApiToken { get; set; } = default!;
}
