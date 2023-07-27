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


Roadmap
--------------------------------------------------------------------------

* Check if there is API for webhooks (client side, as well as server side)
* Write documentation in the README.md
* Return ApiResponse<T> (rather than T), for folks that prefer responses rather than exceptions
* Complete the API / object XML documentation
* Implement Github CI/CD (for libraries and cli tool)
* Converter from `System.Net.Mail.MailMessage` to Resend equiv
* Target multiple frameworks (.NET Standard, .NET 6) -- rather than .NET 7
