namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    public record ImportOffersRequest
    {
        [JsonPropertyName("storeId")]
        public required string StoreId { get; init; }

        [JsonPropertyName("items")]
        public required List<Offer> Items { get; init; }
    }
}
