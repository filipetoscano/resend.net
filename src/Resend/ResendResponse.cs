namespace Resend;

/// <summary>
/// Response from Resend API.
/// </summary>
public class ResendResponse
{
    private readonly bool _success;
    private readonly ResendRateLimit? _limit;
    private readonly ResendException? _exception;


    /// <summary />
    public ResendResponse()
    {
        _success = true;
        _limit = null;
    }


    /// <summary />
    public ResendResponse( ResendRateLimit? limit )
    {
        _success = true;
        _limit = limit;
    }


    /// <summary />
    public ResendResponse( ResendException exception, ResendRateLimit? limit )
    {
        _success = false;
        _limit = limit;
        _exception = exception;
    }


    /// <summary>
    /// Gets whether the invocation was successful or not.
    /// </summary>
    public bool Success
    {
        get => _success;
    }


    /// <summary />
    public ResendRateLimit? Limits
    {
        get => _limit;
    }


    /// <summary>
    /// Gets the error in case of an unsuccessful execution.
    /// </summary>
    public ResendException? Exception
    {
        get => _exception;
    }
}


/// <summary>
/// Response from Resend API that, whenever successful, returns
/// content.
/// </summary>
public class ResendResponse<T> : ResendResponse
{
    private readonly T? _value;


    /// <summary />
    public ResendResponse( T value, ResendRateLimit? limit )
        : base( limit )
    {
        _value = value;
    }


    /// <summary />
    public ResendResponse( ResendException exception, ResendRateLimit? limit )
        : base( exception, limit )
    {
    }


    /// <summary>
    /// Gets the response content, but only if the invocation was successful.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the invocation failed.
    /// </exception>
    public T Content
    {
        get
        {
            if ( _value == null )
                throw new InvalidOperationException();

            return _value;
        }
    }
}
