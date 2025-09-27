
namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BranchDayStoreSchedule
    {

        [JsonPropertyName("storeId")]
        public required string StoreId { get; init; }

        [JsonPropertyName("open"), JsonConverter(typeof(TimespanJsonConverter))]
        public TimeSpan Open { get; init; }

        [JsonPropertyName("closed"), JsonConverter(typeof(TimespanJsonConverter))]
        public TimeSpan Closed { get; init; }
    }
}
