namespace FourTwenty.LokoMerchant.Client.Converters
{
    /// <summary>
    /// Converts <see cref="OrderStatus"/> objects to and from JSON using <see cref="System.Text.Json"/>.
    /// </summary>
    /// <remarks>
    /// This converter reads and writes the <c>Value</c> property of <see cref="OrderStatus"/> as a JSON string.
    /// </remarks>
    public class OrderStatusJsonConverter : JsonConverter<OrderStatus>
    {
        public override OrderStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new(reader.GetString());

        public override void Write(Utf8JsonWriter writer, OrderStatus value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Value);
    }
}
