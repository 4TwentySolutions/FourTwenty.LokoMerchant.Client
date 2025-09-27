namespace FourTwenty.LokoMerchant.Client.Models
{
    public record Option
    {
        [JsonPropertyName("sku")]
        public required string Sku { get; init; }
        [JsonPropertyName("title")]
        public required string Title { get; init; }

        [JsonPropertyName("media")]
        public required string Media { get; init; }

        [JsonPropertyName("offers")]
        public required List<MenuOffer> Offers { get; init; }
    }
}
