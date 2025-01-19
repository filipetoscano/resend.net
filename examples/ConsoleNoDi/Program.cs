using Microsoft.Extensions.Options;
using Resend;


/*
 * 
 */
var apiToken = Environment.GetEnvironmentVariable( "RESEND_APITOKEN" );

if ( apiToken == null )
{
    Console.Error.WriteLine( "err: Environnment variable RESEND_APITOKEN is not defined" );
    return;
}


/*
 * 
 */
var options = Options.Create( new ResendClientOptions()
{
    ApiToken = apiToken,
} );

var resend = new ResendClient( options, new HttpClient() );


/*
 * 
 */
try
{
    var resp = await resend.EmailSendAsync( new EmailMessage()
    {
        From = "you@example.com",
        To = "user@gmail.com",
        Subject = "Console - No DI",
        HtmlBody = "<p>Congrats on sending your <strong>first email</strong>!</p>",
    } );

    Console.WriteLine( "Id={0}", resp.Content );
}
catch ( ResendException ex )
{
    Console.Error.WriteLine( "err: {0} - {1}", ex.ErrorType, ex.Message );
}
