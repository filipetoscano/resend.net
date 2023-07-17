namespace Resend.Net;

public class ApiKeyData
{
}


public class ApiKey
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public DateTime MomentCreated { get; set; }
}
