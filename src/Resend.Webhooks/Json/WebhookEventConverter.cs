using System.Text.Json;
using System.Text.Json.Serialization;

namespace Resend.Webhooks;

/// <summary />
public class WebhookEventConverter : JsonConverter<WebhookEvent>
{
    private readonly JsonStringEnumValueConverter<Resend.WebhookEvent> _wet;
    private readonly JsonUtcDateTimeConverter _utc;

    /// <summary />
    public WebhookEventConverter()
    {
        _wet = new JsonStringEnumValueConverter<Resend.WebhookEvent>();
        _utc = new JsonUtcDateTimeConverter();
    }


    /// <inheritdoc />
    public override WebhookEvent? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        var value = new WebhookEvent();


        /*
         * 
         */
        if ( reader.TokenType != JsonTokenType.StartObject )
            throw new JsonException( "Expected StartObject" );


        /*
         * 
         */
        reader.Read();

        if ( reader.TokenType != JsonTokenType.PropertyName )
            throw new JsonException( "Expected PropertyName" );

        if ( reader.GetString() != "type" )
            throw new JsonException( "Expected 'type' property" );

        reader.Read();
        value.EventType = _wet.Read( ref reader, typeof( Resend.WebhookEvent ), options );


        /*
         * 
         */
        reader.Read();

        if ( reader.TokenType != JsonTokenType.PropertyName )
            throw new JsonException( "Expected PropertyName" );

        if ( reader.GetString() != "created_at" )
            throw new JsonException( "Expected 'created_at' property" );

        reader.Read();
        value.MomentCreated = _utc.Read( ref reader, typeof( DateTime ), options );


        /*
         * 
         */
        reader.Read();

        if ( reader.TokenType != JsonTokenType.PropertyName )
            throw new JsonException( "Expected PropertyName" );

        if ( reader.GetString() != "data" )
            throw new JsonException( "Expected 'data' property" );

        reader.Read();

        if ( value.EventType.ToString().StartsWith( "Email" ) == true )
        {
            var t1 = typeof( EmailEventData );
            var o1 = (JsonConverter<EmailEventData>) options.GetConverter( t1 );

            var data = o1.Read( ref reader, t1, options );

            if ( data == null )
                throw new JsonException( "Expected non-null data" );

            value.Data = data;
        }
        else if ( value.EventType.ToString().StartsWith( "Contact" ) == true )
        {
            var t2 = typeof( ContactEventData );
            var o2 = (JsonConverter<ContactEventData>) options.GetConverter( t2 );

            var data = o2.Read( ref reader, t2, options );

            if ( data == null )
                throw new JsonException( "Expected non-null data" );

            value.Data = data;
        }
        else
        {
            throw new NotSupportedException( $"Unexpected '{value.EventType}' event type" );
        }


        /*
         * 
         */
        reader.Read();

        if ( reader.TokenType != JsonTokenType.EndObject )
            throw new JsonException( "Expected EndObject" );

        return value;
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, WebhookEvent value, JsonSerializerOptions options )
    {
        /*
         * 
         */
        writer.WriteStartObject();

        writer.WritePropertyName( "type" );
        _wet.Write( writer, value.EventType, options );

        writer.WritePropertyName( "created_at" );
        _utc.Write( writer, value.MomentCreated, options );


        /*
         * 
         */
        writer.WritePropertyName( "data" );

        if ( value.EventType.ToString().StartsWith( "Email" ) == true )
        {
            var t1 = typeof( EmailEventData );
            var o1 = (JsonConverter<EmailEventData>) options.GetConverter( t1 );

            o1.Write( writer, value.DataAs<EmailEventData>(), options );
        }
        else if ( value.EventType.ToString().StartsWith( "Contact" ) == true )
        {
            var t2 = typeof( ContactEventData );
            var o2 = (JsonConverter<ContactEventData>) options.GetConverter( t2 );

            o2.Write( writer, value.DataAs<ContactEventData>(), options );
        }
        else
        {
            throw new NotSupportedException( $"Unexpected '{value.EventType}' event type" );
        }


        /*
         * 
         */
        writer.WriteEndObject();
    }
}
