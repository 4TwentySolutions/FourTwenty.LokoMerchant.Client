namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    /// <summary>
    /// Represents a request to update the status of an order in the Loko Merchant system.
    /// </summary>
    public record UpdateOrderStatusRequest
    {
        /// <summary>
        /// The new status to set for the order.
        /// </summary>
        [JsonPropertyName("status")]
        public required OrderStatus Status { get; init; }

        /// <summary>
        /// The updated cooking time for the order, in minutes. Optional.
        /// </summary>
        [JsonPropertyName("cookingTime")]
        public int? CookingTime { get; init; }

        /// <summary>
        /// The list of items with their fulfilled quantities for partial fulfillment. Optional.
        /// </summary>
        [JsonPropertyName("items"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<PartialOrderItem>? Items { get; init; }
    }
}
