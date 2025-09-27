namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BaseSchedule
    {
        [JsonPropertyName("open"), JsonConverter(typeof(TimespanJsonConverter))]
        public TimeSpan Open { get; init; }

        [JsonPropertyName("closed"), JsonConverter(typeof(TimespanJsonConverter))]
        public TimeSpan Closed { get; init; }
    }
}
