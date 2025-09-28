namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    /// <summary>
    /// Provides methods for managing and retrieving orders in the Loko Merchant system.
    /// </summary>
    public interface IOrdersProvider
    {
        /// <summary>
        /// Retrieves a paged list of orders based on the specified filters and query parameters.
        /// </summary>
        /// <param name="request">The request containing filter and query parameters.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>Paged response containing orders.</returns>
        Task<PagedResponse<OrderResponse>?> GetOrders(GetOrdersRequest request, CancellationToken ct = default);

        /// <summary>
        /// Retrieves a specific order by its unique identifier.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>The order response if found; otherwise, null.</returns>
        Task<OrderResponse?> GetOrder(string orderId, CancellationToken ct = default);

        /// <summary>
        /// Updates the status of a specific order.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to update.</param>
        /// <param name="request">The request containing the new status and optional details.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateOrderStatus(string orderId, UpdateOrderStatusRequest request, CancellationToken ct = default);
    }
}
