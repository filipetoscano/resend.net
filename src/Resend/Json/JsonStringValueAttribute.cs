using System.Text.Json.Serialization;

namespace Resend;

/// <summary>
/// Specifies the enum string value that is present in the JSON when serializing and deserializing.
/// </summary>
[AttributeUsage( AttributeTargets.Field, Inherited = false, AllowMultiple = false )]
public sealed class JsonStringValueAttribute : JsonAttribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="JsonStringValueAttribute"/> with the specified string value.
    /// </summary>
    /// <param name="value">The string value of the enum.</param>
    public JsonStringValueAttribute( string value )
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }
}
