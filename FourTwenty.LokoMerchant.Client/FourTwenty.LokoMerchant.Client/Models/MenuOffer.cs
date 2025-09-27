namespace FourTwenty.LokoMerchant.Client.Models
{
    public record MenuOffer : BaseOffer
    {
        [JsonPropertyName("storeId")]
        public required string StoreId { get; init; }

        [JsonPropertyName("sortOrder")]
        public int? SortOrder { get; init; }
    }
}
