namespace FourTwenty.LokoMerchant.Client.Models
{
    public record Offer : BaseOffer
    {
        /// <summary>
        /// SKU of the product this offer belongs to
        /// </summary>
        [JsonPropertyName("sku")]
        public required string Sku { get; init; }

    }
}
