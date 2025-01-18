using Resend.Webhooks;

namespace Resend.ApiServer.WebhookHandlers;

/// <summary />
public class Handler2 : IWebhookHandler
{
    private readonly ILogger<Handler2> _logger;

    /// <summary />
    public Handler2( ILogger<Handler2> logger )
    {
        _logger = logger;
    }


    /// <inheritdoc />
    public async Task<IResult> HandleValid( WebhookContext context )
    {
        _logger.LogInformation( "Handler 2: Always say BadRequest!" );

        await Task.Yield();

        return Results.BadRequest();
    }


    /// <inheritdoc />
    public async Task<IResult> HandleInvalid( WebhookContext context )
    {
        await Task.Yield();

        _logger.LogError( "Invalid {MessageId}: {ErrorCode} - {Message}", context.MessageId, context.Exception?.ErrorCode, context.Exception?.Message );

        return Results.BadRequest();
    }
}