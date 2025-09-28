namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents an attribute of an order item in the Loko Merchant system.
    /// </summary>
    public record OrderItemAttributeResponse
    {
        /// <summary>
        /// The unique identifier of the attribute.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        /// <summary>
        /// The name of the attribute.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        /// <summary>
        /// The SKU of the attribute.
        /// </summary>
        [JsonPropertyName("sku")]
        public string? Sku { get; init; }

        /// <summary>
        /// The offer ID associated with the attribute.
        /// </summary>
        [JsonPropertyName("offerId")]
        public string? OfferId { get; init; }

        /// <summary>
        /// The quantity of the attribute.
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; init; }

        /// <summary>
        /// The price details for the attribute.
        /// </summary>
        [JsonPropertyName("price")]
        public OrderPriceResponse? Price { get; init; }

        /// <summary>
        /// The net price details for the attribute.
        /// </summary>
        [JsonPropertyName("netPrice")]
        public OrderPriceResponse? NetPrice { get; init; }

        /// <summary>
        /// The list price details for the attribute.
        /// </summary>
        [JsonPropertyName("listPrice")]
        public OrderPriceResponse? ListPrice { get; init; }

        /// <summary>
        /// The net list price details for the attribute.
        /// </summary>
        [JsonPropertyName("netListPrice")]
        public OrderPriceResponse? NetListPrice { get; init; }

        /// <summary>
        /// The discount price details for the attribute.
        /// </summary>
        [JsonPropertyName("discountPrice")]
        public OrderPriceResponse? DiscountPrice { get; init; }
    }
}
