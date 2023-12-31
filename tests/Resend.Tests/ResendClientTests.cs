﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
using Resend.ApiServer;

namespace Resend.Tests;

/// <summary />
public class ResendClientTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly IResend _resend;


    /// <summary />
    public ResendClientTests( WebApplicationFactory<Program> factory )
    {
        _factory = factory;

        var http = _factory.CreateClient();

        var opt = Options.Create( new ResendClientOptions()
        {
            ApiUrl = http.BaseAddress!.ToString(),
        } ) ;

        _resend = new ResendClient( opt, http );
    }


    /// <summary />
    [Fact]
    public async Task EmailSend()
    {
        var email = new EmailMessage();
        email.Subject = "Unit testing";
        email.From = "from@example.com";
        email.To = "to@example.com";
        email.HtmlBody = "From unit test!";

        var resp = await _resend.EmailSendAsync( email );

        Assert.NotNull( resp );
        Assert.True( resp.Success );
    }


    /// <summary />
    [Fact]
    public async Task EmailRetrieve()
    {
        var anyId = Guid.NewGuid();

        var resp = await _resend.EmailRetrieveAsync( anyId );

        Assert.NotNull( resp );
        Assert.True( resp.Success );
        Assert.NotNull( resp.Content );
        Assert.Equal( "from@example.com", resp.Content.From.Email );
        Assert.Single( resp.Content.To );
        Assert.Null( resp.Content.TextBody );
        Assert.NotNull( resp.Content.HtmlBody );
    }


    /// <summary />
    [Fact]
    public async Task DomainList()
    {
        var resp = await _resend.DomainListAsync();

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task DomainAdd()
    {
        var resp = await _resend.DomainAddAsync( "example.com", DeliveryRegion.UsEast1 );

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task DomainDelete()
    {
        var resp = await _resend.DomainDeleteAsync( Guid.NewGuid() );

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task DomainVerify()
    {
        var resp = await _resend.DomainVerifyAsync( Guid.NewGuid() );

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task DomainRetrieve()
    {
        var resp = await _resend.DomainRetrieveAsync( Guid.NewGuid() );

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyList()
    {
        var resp = await _resend.ApiKeyListAsync();

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyCreate()
    {
        var resp = await _resend.ApiKeyCreateAsync( "resend-me", Permission.FullAccess );

        Assert.NotNull( resp );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyDelete()
    {
        var resp = await _resend.ApiKeyDelete( Guid.NewGuid() );

        Assert.NotNull( resp );
    }
}
