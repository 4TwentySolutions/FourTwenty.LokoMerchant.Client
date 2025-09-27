namespace FourTwenty.LokoMerchant.Client.Converters
{
    public class WebhookEventJsonConverter : JsonConverter<WebhookEvent>
    {
        public override WebhookEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new(reader.GetString());

        public override void Write(Utf8JsonWriter writer, WebhookEvent value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Value);
    }
}
