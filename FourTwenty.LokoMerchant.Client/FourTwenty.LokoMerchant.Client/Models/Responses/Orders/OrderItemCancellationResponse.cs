namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents a cancellation of an order item in the Loko Merchant system.
    /// </summary>
    public record OrderItemCancellationResponse
    {
        /// <summary>
        /// The actor who performed the cancellation (e.g., customer, merchant).
        /// </summary>
        [JsonPropertyName("actor"), JsonConverter(typeof(LowerCaseEnumConverter<CancellationActor>))]
        public CancellationActor? Actor { get; init; }

        /// <summary>
        /// The quantity of the item that was cancelled.
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; init; }

        /// <summary>
        /// The reason code for the cancellation.
        /// </summary>
        [JsonPropertyName("reason")]
        public string? Reason { get; init; }

        /// <summary>
        /// The detailed reason text for the cancellation.
        /// </summary>
        [JsonPropertyName("reasonText")]
        public string? ReasonText { get; init; }

        /// <summary>
        /// The date and time when the cancellation was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; init; }
    }
}
