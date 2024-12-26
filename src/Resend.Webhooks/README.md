resend webhooks
==========================================================================

[![CI](https://github.com/filipetoscano/resend.net/workflows/CI/badge.svg)](https://github.com/filipetoscano/resend.net/actions)
[![NuGet](http://img.shields.io/nuget/vpre/resend.webhooks.svg?label=NuGet)](https://www.nuget.org/packages/Resend.Webhooks/)


Installing via NuGet
--------------------------------------------------------------------------

Package is published in the [NuGet](https://www.nuget.org/packages/Resend.Webhooks/) gallery.

From the command-line:

```
> dotnet add package Resend.Webhooks
```

From within Visual Studio using Package Manager Console:

```
PM> Install-Package Resend.Webhooks
```


Getting started
--------------------------------------------------------------------------

In the startup of your application, configure the DI container as follows:

```
using Resend.Webhooks;

builder.Services.AddOptions();
builder.Services.AddOptions<WebhookValidatorOptions>();
builder.Services.AddTransient<WebhookValidator>();
builder.Services.Configure<WebhookValidatorOptions>( o =>
{
    o.Secret = Environment.GetEnvironmentVariable( "RESEND_WEBHOOK_SECRET" )!;
} );


// At the start
app.Use( async ( context, next ) =>
{
    context.Request.EnableBuffering();

    await next();
} );
```

For a sample implementation of a Resend Webhook sink, see:

* [WebhookSinkController.cs](https://github.com/filipetoscano/resend.net/blob/master/tools/Resend.ApiServer/Controllers/)
