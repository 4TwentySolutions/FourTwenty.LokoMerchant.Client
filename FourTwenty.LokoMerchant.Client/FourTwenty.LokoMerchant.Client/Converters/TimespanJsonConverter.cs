namespace FourTwenty.LokoMerchant.Client.Converters
{
    public class TimespanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                if (TimeSpan.TryParseExact(stringValue, @"hh\:mm", null, out var timeSpanValue))
                    return timeSpanValue;
            }
            throw new JsonException("Invalid JSON token for TimeSpan type. Expected format 'hh:mm'.");
        }
        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(@"hh\:mm"));
        }
    }
}
