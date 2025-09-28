namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents the price details of an order or order item in the Loko Merchant system.
    /// </summary>
    public record OrderPriceResponse
    {
        /// <summary>
        /// The currency of the price (e.g., UAH).
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }

        /// <summary>
        /// The value of the price.
        /// </summary>
        [JsonPropertyName("value")]
        public required decimal Value { get; init; }
    }
}
