namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    /// <summary>
    /// Standard response containing an operation or resource identifier.
    /// Commonly returned from import operations and resource creation endpoints.
    /// </summary>
    public record IdResponse
    {
        /// <summary>
        /// The unique identifier returned by the operation, such as an import job ID or resource ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; init; }
    }
}
