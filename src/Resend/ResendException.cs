using System.Net;

namespace Resend;

/// <summary />
public class ResendException : ApplicationException
{
    /// <summary />
    public ResendException( HttpStatusCode statusCode, ErrorType errorType, string message )
        : base( message )
    {
        this.StatusCode = statusCode;
        this.ErrorType = errorType;
    }


    /// <summary />
    public ResendException( int statusCode, ErrorType errorType, string message )
        : base( message )
    {
        this.StatusCode = (HttpStatusCode) statusCode;
        this.ErrorType = errorType;
    }


    /// <summary />
    public ResendException( HttpStatusCode statusCode, ErrorType errorType, string message, Exception? innerException )
        : base( message, innerException )
    {
        this.StatusCode = statusCode;
        this.ErrorType = errorType;
    }


    /// <summary />
    public ResendException( int statusCode, ErrorType errorType, string message, Exception? innerException )
        : base( message, innerException )
    {
        this.StatusCode = (HttpStatusCode) statusCode;
        this.ErrorType = errorType;
    }


    /// <summary />
    public HttpStatusCode StatusCode { get; }

    /// <summary />
    public ErrorType ErrorType { get; }
}