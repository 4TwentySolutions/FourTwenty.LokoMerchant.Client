namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    /// <summary>
    /// Represents a paged response containing a list of items and the total count.
    /// </summary>
    public record PagedResponse<T>
    {
        /// <summary>
        /// The total number of items available.
        /// </summary>
        [JsonPropertyName("total")]
        public int? Total { get; init; }

        /// <summary>
        /// The list of items in the current page.
        /// </summary>
        [JsonPropertyName("items")]
        public List<T>? Items { get; init; }
    }
}
