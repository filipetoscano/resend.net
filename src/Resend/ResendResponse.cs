namespace Resend;


/// <summary>
/// Response from Resend API.
/// </summary>
public class ResendResponse
{
    protected readonly bool _success;


    /// <summary />
    public ResendResponse()
    {
        _success = true;
    }


    /// <summary>
    /// Gets whether the invocation was successful or not.
    /// </summary>
    public bool Success
    {
        get
        {
            return _success;
        }
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
    public ResendResponse( T value )
        : base()
    {
        _value = value;
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
