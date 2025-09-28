namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents an item within an order in the Loko Merchant system.
    /// </summary>
    public record OrderItemResponse
    {
        /// <summary>
        /// The unique identifier of the order item.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        /// <summary>
        /// The unique identifier of the product associated with the item.
        /// </summary>
        [JsonPropertyName("productId")]
        public string? ProductId { get; init; }

        /// <summary>
        /// The unique identifier of the offer associated with the item.
        /// </summary>
        [JsonPropertyName("offerId")]
        public string? OfferId { get; init; }

        /// <summary>
        /// The SKU of the item.
        /// </summary>
        [JsonPropertyName("sku")]
        public string? Sku { get; init; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        /// <summary>
        /// The quantity of the item ordered.
        /// </summary>
        [JsonPropertyName("quantityOrdered")]
        public int? QuantityOrdered { get; init; }

        /// <summary>
        /// The quantity of the item fulfilled.
        /// </summary>
        [JsonPropertyName("quantityFulfilled")]
        public int? QuantityFulfilled { get; init; }

        /// <summary>
        /// The price details for the item.
        /// </summary>
        [JsonPropertyName("itemPrice")]
        public OrderPriceResponse? ItemPrice { get; init; }

        /// <summary>
        /// The list price details for the item.
        /// </summary>
        [JsonPropertyName("listPrice")]
        public OrderPriceResponse? ListPrice { get; init; }

        /// <summary>
        /// The net price details for the item.
        /// </summary>
        [JsonPropertyName("netPrice")]
        public OrderPriceResponse? NetPrice { get; init; }

        /// <summary>
        /// The net list price details for the item.
        /// </summary>
        [JsonPropertyName("netListPrice")]
        public OrderPriceResponse? NetListPrice { get; init; }

        /// <summary>
        /// The discount price details for the item.
        /// </summary>
        [JsonPropertyName("discountPrice")]
        public OrderPriceResponse? DiscountPrice { get; init; }

        /// <summary>
        /// The list of attributes for the item.
        /// </summary>
        [JsonPropertyName("attributes")]
        public List<OrderItemAttributeResponse>? Attributes { get; init; }

        /// <summary>
        /// The list of cancellations for the item.
        /// </summary>
        [JsonPropertyName("cancellations")]
        public List<OrderItemCancellationResponse>? Cancellations { get; init; }
    }
}
