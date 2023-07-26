using McMaster.Extensions.CommandLineUtils;
using Resend.Net;

namespace Resend.Cli.Domain;

/// <summary />
[Command( "list" )]
public class DomainListCommand
{
    private readonly IResend _resend;


    /// <summary />
    public DomainListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var domains = await _resend.DomainListAsync();

        foreach ( var d in domains )
            Console.WriteLine( "{0} {1} {2} {3} {4}", d.Id, d.Name, d.Region, d.Status, d.MomentCreated );

        return 0;
    }
}
