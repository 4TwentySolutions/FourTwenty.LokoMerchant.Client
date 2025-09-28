namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents the courier details for an order in the Loko Merchant system.
    /// </summary>
    public record OrderCourierResponse
    {
        /// <summary>
        /// The unique identifier of the courier.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        /// <summary>
        /// The first name of the courier.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; init; }

        /// <summary>
        /// The phone number of the courier.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; init; }
    }
}
