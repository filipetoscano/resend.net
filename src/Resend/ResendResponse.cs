using System.Net;

namespace Resend;


/// <summary>
/// Response from Resend API.
/// </summary>
public class ResendResponse
{
    private readonly bool _success;
    private readonly HttpStatusCode? _statusCode;
    private readonly Exception? _exception;
    private readonly string? _error;


    /// <summary />
    public ResendResponse()
    {
        _success = true;
    }


    /// <summary />
    public ResendResponse( HttpStatusCode statusCode )
    {
        _success = false;
        _statusCode = statusCode;
    }


    /// <summary />
    public ResendResponse( string error )
    {
        _success = false;
        _error = error;
    }


    /// <summary />
    public ResendResponse( Exception exception, string error )
    {
        _success = false;
        _exception = exception;
        _error = error;
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


    /// <summary />
    public ResendResponse( HttpStatusCode statusCode )
        : base( statusCode )
    {
    }


    /// <summary />
    public ResendResponse( string error )
        : base( error )
    {
    }


    /// <summary />
    public ResendResponse( Exception exception, string error )
        : base( exception, error )
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
