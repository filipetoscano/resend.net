namespace Resend;

/// <summary />
public class ResendEmailAddress
{
    /// <summary>
    /// Address so that emails are considered as delivered.
    /// </summary>
    public const string Delivered = "delivered@resend.dev";

    /// <summary>
    /// Address so that emails are flagged as bounced.
    /// </summary>
    public const string Bounced = "bounced@resend.dev";

    /// <summary>
    /// Address so that emails are 'marked as spam'.
    /// </summary>
    public const string MarkedAsSpam = "complained@resend.dev";
}
