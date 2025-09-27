
namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BranchDayStoreSchedule : BaseSchedule
    {

        [JsonPropertyName("storeId")]
        public required string StoreId { get; init; }

    }
}
