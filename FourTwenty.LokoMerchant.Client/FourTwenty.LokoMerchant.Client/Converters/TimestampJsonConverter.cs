namespace FourTwenty.LokoMerchant.Client.Converters
{
    public class TimestampJsonConverter : JsonConverter<long?>
    {
        public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.String:
                    var stringValue = reader.GetString();
                    if (long.TryParse(stringValue, out var longValue))
                        return longValue;
                    break;
            }

            throw new JsonException("Invalid JSON token for long? type.");
        }

        public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString());
            else
                writer.WriteNullValue();
        }
    }
}
