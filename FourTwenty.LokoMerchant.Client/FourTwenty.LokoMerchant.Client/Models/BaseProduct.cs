namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BaseProduct
    {
        [JsonPropertyName("sku")]
        public required string Sku { get; init; }
        [JsonPropertyName("title")]
        public required string Title { get; init; }
        [JsonPropertyName("description")]
        public string? Description { get; init; }


        [JsonPropertyName("unit")]
        public required string Unit { get; init; }
        [JsonPropertyName("media")]
        public required string Media { get; init; }

    }
}
