﻿using McMaster.Extensions.CommandLineUtils;
using Resend.Net;
using System.ComponentModel.DataAnnotations;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "delete" )]
public class DomainDeleteCommand
{
    private readonly IResend _resend;


    /// <summary />
    [Argument( 0, Description = "Domain identifier" )]
    [Required]
    public Guid DomainId { get; set; }


    /// <summary />
    public DomainDeleteCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        await _resend.DomainDeleteAsync( this.DomainId );

        return 0;
    }
}
