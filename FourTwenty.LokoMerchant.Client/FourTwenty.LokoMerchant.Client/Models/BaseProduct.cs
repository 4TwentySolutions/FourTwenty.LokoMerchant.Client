namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Base product information containing common properties shared across different product representations.
    /// </summary>
    public record BaseProduct
    {
        /// <summary>
        /// The stock keeping unit (SKU) - a unique identifier for this product.
        /// </summary>
        [JsonPropertyName("sku")]
        public required string Sku { get; init; }

        /// <summary>
        /// The display title/name of the product.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; init; }

        /// <summary>
        /// A detailed description of the product, including ingredients, preparation methods, or other relevant information.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; init; }

        /// <summary>
        /// The unit of measurement for this product (e.g., "piece", "kg", "liter", "portion").
        /// </summary>
        [JsonPropertyName("unit")]
        public required string Unit { get; init; }

        /// <summary>
        /// URL or identifier for the product's media/image representation.
        /// </summary>
        [JsonPropertyName("media")]
        public required string Media { get; init; }

    }
}
