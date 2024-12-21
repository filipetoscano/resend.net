using Resend.Webhooks;

namespace Resend.ApiServer;

/// <summary />
public partial class Program
{
    /// <summary />
    public static void Main( string[] args )
    {
        /*
         * 
         */
        var builder = WebApplication.CreateBuilder( args );

        builder.Services.AddControllers();

        builder.Services.AddOptions();
        builder.Services.AddOptions<WebhookValidatorOptions>();
        builder.Services.AddTransient<WebhookValidator>();
        builder.Services.Configure<WebhookValidatorOptions>( c =>
        {
            c.Secret = Environment.GetEnvironmentVariable( "RESEND_WEBHOOK_SECRET" )!;
        } );


        /*
         * 
         */
        var app = builder.Build();

        app.UseAuthorization();

        app.Use( async ( context, next ) =>
        {
            context.Request.EnableBuffering();

            await next();
        } );

        app.MapControllers();

        app.Run();
    }
}
