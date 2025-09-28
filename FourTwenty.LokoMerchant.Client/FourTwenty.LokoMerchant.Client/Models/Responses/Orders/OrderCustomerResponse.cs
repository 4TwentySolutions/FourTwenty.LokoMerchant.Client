namespace FourTwenty.LokoMerchant.Client.Models.Responses.Orders
{
    /// <summary>
    /// Represents the customer details for an order in the Loko Merchant system.
    /// </summary>
    public record OrderCustomerResponse
    {
        /// <summary>
        /// The first name of the customer.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; init; }

        /// <summary>
        /// The last name of the customer.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; init; }

        /// <summary>
        /// The phone number of the customer.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; init; }
    }
}
