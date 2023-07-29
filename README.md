resend
==========================================================================

[![CI](https://github.com/filipetoscano/resend.net/workflows/CI/badge.svg)](https://github.com/filipetoscano/resend.net/actions)
[![NuGet](http://img.shields.io/nuget/vpre/resend.svg?label=NuGet)](https://www.nuget.org/packages/Resend/)

.NET client for [resend](https://resend.com), an email API, written in C#.


Installing via NuGet
--------------------------------------------------------------------------

Package is published in the [NuGet](https://www.nuget.org/packages/Resend/) gallery.

From the command-line:

```
> dotnet add package Resend
```

From within Visual Studio using Package Manager Console:

```
PM> Install-Package Resend
```


Getting started
--------------------------------------------------------------------------

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


Send an email using the injected `IResend` instance:

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
        message.From = "onboarding@resend.dev";
        message.To.Add( "myapp@example.com" );
        message.Subject = "Hello!";
        message.HtmlBody = "<div><strong>Greetings<strong> 👋🏻 from .NET</div>";

        await _resend.EmailSendAsync( message );
    }
}
```


`resend` command-line tool
--------------------------------------------------------------------------

In addition to the .NET library, this repository also releases a cross platform
command line interface program to invoke the API. This program is available as
a .NET tool.

```
0.1.0

Command-line tool for Resend API

Usage: resend [command] [options]

Options:
  --version     Show version information.
  -?|-h|--help  Show help information.

Commands:
  api-key       API key management
  domain        Email (sender) domain management
  email         Send emails
  webhook       Webhook management

Run 'resend [command] -?|-h|--help' for more information about a command.
```

Each command has sub-commands: you can enumerate the sub-commands with
the `--help` flag, eg `resend email --help`.


Roadmap
--------------------------------------------------------------------------

* Check if there is API for webhooks (client side, as well as server side)
* Write documentation in the README.md
* Return ApiResponse<T> (rather than T), for folks that prefer responses rather than exceptions
* Complete the API / object XML documentation
* Implement Github CI/CD (for libraries and cli tool)
* Target multiple frameworks (.NET Standard, .NET 6) -- rather than .NET 7
