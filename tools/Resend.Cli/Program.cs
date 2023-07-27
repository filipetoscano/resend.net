using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Resend.Net;

namespace Resend.Cli;

/// <summary />
[Command( "resend", Description = "Command-line for Resend.net" )]
[Subcommand( typeof( ApiKeyCommand ) )]
[Subcommand( typeof( DomainCommand ) )]
[Subcommand( typeof( EmailCommand ) )]
[HelpOption]
[VersionOption( "1.0.0" )]
public class Program
{
    /// <summary />
    public static int Main( string[] args )
    {
        /*
         * 
         */
        var app = new CommandLineApplication<Program>();

        var services = new ServiceCollection()
            .AddOptions()
            .Configure<ResendClientOptions>( o =>
            {
                o.ApiToken = Environment.GetEnvironmentVariable( "RESEND_APITOKEN" )!;
            } )
            //.AddHttpClient<ResendClient>()
            .AddHttpClient()
            .AddTransient<IResend, ResendClient>()
            .BuildServiceProvider();


        /*
         * 
         */
        try
        {
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection( services );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "ftl: unhandled exception during setup" );
            Console.WriteLine( ex.ToString() );

            return 2;
        }


        /*
         * 
         */
        try
        {
            return app.Execute( args );
        }
        catch ( UnrecognizedCommandParsingException ex )
        {
            Console.WriteLine( "err: " + ex.Message );

            return 2;
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "ftl: unhandled exception during execution" );
            Console.WriteLine( ex.ToString() );

            return 2;
        }
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
