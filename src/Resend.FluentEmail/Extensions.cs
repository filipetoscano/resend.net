using FluentEmail.Core.Interfaces;
using Microsoft.Extensions.Options;
using Resend.FluentEmail;
using Resend.Net;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary />
public static class FluentEmailSendGridBuilderExtensions
{
    /// <summary />
    public static FluentEmailServicesBuilder AddResend( this FluentEmailServicesBuilder builder )
    {
        var sd1 = ServiceDescriptor.Singleton<IResend>( ( sp ) =>
        {
            var opt = sp.GetRequiredService<IOptions<ResendClientOptions>>();
            var http = sp.GetRequiredService<HttpClient>();

            return new ResendClient( opt, http );
        } );

        var sd2 = ServiceDescriptor.Singleton<ISender>( ( sp ) =>
        {
            var resend = sp.GetRequiredService<IResend>();

            return new ResendSender( resend );
        } );

        builder.Services.Add( sd1 );
        builder.Services.Add( sd2 );

        return builder;
    }
}
