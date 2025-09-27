namespace FourTwenty.LokoMerchant.Client.Converters
{
    public class DateJsonConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException($"Invalid date format. Expected format is {Format}.");

            var dateString = reader.GetString();
            return DateTime.TryParseExact(dateString, Format, null, System.Globalization.DateTimeStyles.None, out DateTime date)
                ? date
                : throw new JsonException($"Invalid date format. Expected format is {Format}.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(Format));

    }
}
