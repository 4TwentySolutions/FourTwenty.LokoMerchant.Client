namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    /// <summary>
    /// Represents query parameters for filtering and paginating orders in the Loko Merchant system.
    /// </summary>
    public record GetOrdersRequest
    {
        /// <summary>
        /// List of branch IDs to filter orders by branch.
        /// </summary>
        public List<string>? BranchIds { get; init; }

        /// <summary>
        /// List of order statuses to filter orders.
        /// </summary>
        public List<OrderStatus>? Statuses { get; init; }

        /// <summary>
        /// Filter orders created after this Unix timestamp (seconds).
        /// </summary>
        public long? CreatedAtFrom { get; init; }

        /// <summary>
        /// Filter orders created before this Unix timestamp (seconds).
        /// </summary>
        public long? CreatedAtTo { get; init; }

        /// <summary>
        /// List of fields to sort by. Prefix with '-' for descending order.
        /// </summary>
        public List<string>? Sort { get; init; }

        /// <summary>
        /// Number of items to skip before returning results.
        /// </summary>
        public int? Offset { get; init; }

        /// <summary>
        /// Maximum number of items to return.
        /// </summary>
        public int? Limit { get; init; }
    }
}
