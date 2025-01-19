using Resend;

namespace WebRazor
{
    public class Program
    {
        public static void Main( string[] args )
        {
            /*
             * 
             */
            var builder = WebApplication.CreateBuilder( args );

            builder.Services.AddRazorPages();

            builder.Services.AddOptions();
            builder.Services.Configure<ResendClientOptions>( o =>
            {
                o.ApiToken = Environment.GetEnvironmentVariable( "RESEND_APITOKEN" )!;
            } );
            builder.Services.AddHttpClient<ResendClient>();
            builder.Services.AddTransient<IResend, ResendClient>();


            /*
             * Configure the HTTP request pipeline.
             */
            var app = builder.Build();

            if ( app.Environment.IsDevelopment() == false )
            {
                app.UseExceptionHandler( "/Error" );
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();


            /*
             * 
             */
            app.Run();
        }
    }
}
