namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    /// <summary>
    /// Represents a partial fulfillment of an order item, specifying the fulfilled quantity and SKU.
    /// </summary>
    public record PartialOrderItem
    {
        /// <summary>
        /// The quantity of the item that has been fulfilled.
        /// </summary>
        [JsonPropertyName("quantityFulfilled")]
        public int QuantityFulfilled { get; init; }

        /// <summary>
        /// The SKU (Stock Keeping Unit) identifier of the item.
        /// </summary>
        [JsonPropertyName("sku")]
        public string? Sku { get; init; }
    }
}
