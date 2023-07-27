resend.net
==========================================================================

.NET client for [resend](https://resend.com), an email API, written in C#.


Installation
--------------------------------------------------------------------------

From the command-line:

```
> dotnet add package Resend.Net
```

From within Visual Studio using Package Manager Console:

```
PM> Install-Package Resend.Net
```


Getting started
--------------------------------------------------------------------------

Configure the dependency injection container:

```
using Resend.Net;

builder.Services
    .AddHttpClient()
    .Configure<ResendClientOptions>( o =>
    {
        o.ApiToken = Environment.GetEnvironmentVariable( "RESEND_APITOKEN" )!;
    } )
    .AddTransient<IResend, ResendClient>()
```


Send an email using the injected `IResend` instance:

```
using Resend.Net;

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
        message.From = "onboarding@resend.dev";
        message.To.Add( "myapp@example.com" );
        message.Subject = "Hello!";
        message.HtmlBody = "<div><strong>Greetings<strong> 👋🏻 from .NET</div>";

        await _resend.EmailSendAsync( message );
    }
}
```


