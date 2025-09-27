namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Represents a product option or variant with its own SKU, title, and offers.
    /// Options are typically variations of a base product (e.g., different sizes, flavors, or configurations).
    /// </summary>
    public record Option
    {
        /// <summary>
        /// The stock keeping unit (SKU) - a unique identifier for this product option.
        /// </summary>
        [JsonPropertyName("sku")]
        public required string Sku { get; init; }

        /// <summary>
        /// The display title/name of this product option.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; init; }

        /// <summary>
        /// URL or identifier for the option's media/image representation.
        /// </summary>
        [JsonPropertyName("media")]
        public required string Media { get; init; }

        /// <summary>
        /// List of pricing and availability offers for this product option.
        /// </summary>
        [JsonPropertyName("offers")]
        public required List<MenuOffer> Offers { get; init; }
    }
}
