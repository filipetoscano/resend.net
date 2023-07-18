using McMaster.Extensions.CommandLineUtils;
using Resend.Net;

namespace Resend.Cli.ApiKey;

/// <summary />
[Command( "list" )]
public class ApiKeyListCommand
{
    private readonly IResend _resend;


    /// <summary />
    public ApiKeyListCommand( IResend resend )
    {
        _resend = resend;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var keys = await _resend.ApiKeyListAsync();

        foreach ( var k in keys )
            Console.WriteLine( "{0} {1}", k.Id, k.Name );

        return 0;
    }
}
