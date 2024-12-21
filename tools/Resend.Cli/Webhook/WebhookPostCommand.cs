using McMaster.Extensions.CommandLineUtils;

namespace Resend.Cli.Webhook;

/// <summary />
[Command( "post" )]
public class WebhookPostCommand
{
    /// <summary />
    [Option( "-i|--input", CommandOptionType.SingleValue, Description = "" )]
    [FileExists]
    public string? EventData { get; set; }

    /// <summary />
    [Option( "-u|--url", CommandOptionType.SingleValue, Description = "Webhook URL" )]
    public string? WebhookUrl { get; set; }

    /// <summary />
    [Option( "-s|--secret", CommandOptionType.SingleValue, Description = "" )]
    public string? SigningSecret { get; set; } = Environment.GetEnvironmentVariable( "RESEND_WEBHOOK_SECRET" );



    /// <summary />
    public WebhookPostCommand()
    {
    }


    /// <summary />
    public Task<int> OnExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
