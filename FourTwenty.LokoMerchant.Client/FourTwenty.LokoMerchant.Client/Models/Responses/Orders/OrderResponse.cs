namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents an order in the Loko Merchant system.
    /// </summary>
    public record OrderResponse
    {
        /// <summary>
        /// The unique identifier of the order.
        /// </summary>
        [JsonPropertyName("id")]
        public required string Id { get; init; }

        /// <summary>
        /// The order number.
        /// </summary>
        [JsonPropertyName("number")]
        public string? Number { get; init; }

        /// <summary>
        /// The unique identifier of the store associated with the order.
        /// </summary>
        [JsonPropertyName("storeId")]
        public string? StoreId { get; init; }

        /// <summary>
        /// The status of the order.
        /// </summary>
        [JsonPropertyName("status"), JsonConverter(typeof(OrderStatusJsonConverter))]
        public OrderStatus? Status { get; init; }

        /// <summary>
        /// The list price details of the order.
        /// </summary>
        [JsonPropertyName("listPrice")]
        public OrderPriceResponse? ListPrice { get; init; }

        /// <summary>
        /// The net price details of the order.
        /// </summary>
        [JsonPropertyName("netPrice")]
        public OrderPriceResponse? NetPrice { get; init; }

        /// <summary>
        /// Any comment associated with the order.
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; init; }

        /// <summary>
        /// The estimated cooking time for the order, in minutes.
        /// </summary>
        [JsonPropertyName("estimatedCookingTime")]
        public int? EstimatedCookingTime { get; init; }

        /// <summary>
        /// The list of items in the order.
        /// </summary>
        [JsonPropertyName("items")]
        public List<OrderItemResponse>? Items { get; init; }

        /// <summary>
        /// The customer details for the order.
        /// </summary>
        [JsonPropertyName("customer")]
        public OrderCustomerResponse? Customer { get; init; }

        /// <summary>
        /// The courier details for the order.
        /// </summary>
        [JsonPropertyName("courier")]
        public OrderCourierResponse? Courier { get; init; }

        /// <summary>
        /// Indicates whether the order is a test order.
        /// </summary>
        [JsonPropertyName("isTest")]
        public bool? IsTest { get; init; }

        /// <summary>
        /// The date and time when the order was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; init; }

        /// <summary>
        /// The date and time when the order was last updated.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; init; }
    }
}