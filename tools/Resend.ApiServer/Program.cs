using Resend.ApiServer.WebhookHandlers;

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

        builder.Services.AddResendWebhooks( c =>
        {
            c.Secret = Environment.GetEnvironmentVariable( "RESEND_WEBHOOK_SECRET" )!;
        } );

        builder.Services.AddScoped<Handler1>();
        builder.Services.AddScoped<Handler2>();


        /*
         * 
         */
        var app = builder.Build();

        app.UseAuthorization();
        app.UseRouting();   // Required before MapResendWebhook

        app.MapControllers();

        app.MapResendWebhook<Handler1>( "/webhook/sink1" );
        app.MapResendWebhook<Handler2>( "/webhook/sink2" );

        app.Run();
    }
}
