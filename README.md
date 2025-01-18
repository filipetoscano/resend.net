Resend .NET SDK
==========================================================================

.NET library for the Resend API.


Install
--------------------------------------------------------------------------

```
> dotnet add package Resend
```


Examples
--------------------------------------------------------------------------

Send email with:

* ASP.NET Controller (WIP)
* Console app (WIP)


Setup
--------------------------------------------------------------------------

First, you need to get an API key, which is available in the
[Resend Dashboard](https://resend.com/).

In the startup of your application, configure the DI container as follows:

```
using Resend;

builder.Services.AddOptions();
builder.Services.AddHttpClient<ResendClient>();
builder.Services.Configure<ResendClientOptions>( o =>
{
    o.ApiToken = Environment.GetEnvironmentVariable( "RESEND_APITOKEN" )!;
} );
builder.Services.AddTransient<IResend, ResendClient>()
```

You can then use the injected `IResend` instance to send emails.


Usage
--------------------------------------------------------------------------

Send your first email:

```
using Resend;

public class FeatureImplementation
{
    private readonly IResend _resend;


    public FeatureImplementation( IResend resend )
    {
        _resend = resend;
    }


    public Task Execute()
    {
        var message = new EmailMessage();
        message.From = "you@example.com";
        message.To.Add( "user@gmail.com" );
        message.Subject = "hello world";
        message.TextBody = "it works!";

        await _resend.EmailSendAsync( message );
    }
}
```


Send email using HTML
--------------------------------------------------------------------------

Send an email custom HTML content:

```
using Resend;

public class FeatureImplementation
{
    private readonly IResend _resend;


    public FeatureImplementation( IResend resend )
    {
        _resend = resend;
    }


    public Task Execute()
    {
        var message = new EmailMessage();
        message.From = "you@example.com";
        message.To.Add( "user@gmail.com" );
        message.Subject = "hello world";
        message.HtmlBody = "<strong>it works!</strong>";

        await _resend.EmailSendAsync( message );
    }
}
```


License
--------------------------------------------------------------------------

MIT License