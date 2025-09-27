namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    /// <summary>
    /// Provides functionality for managing webhook subscriptions and events in the Loko Merchant system.
    /// </summary>
    public interface IWebhooksProvider
    {
        /// <summary>
        /// Retrieves all webhook subscriptions for the authenticated merchant.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A paged response containing the merchant's webhook subscriptions, or null if none exist.</returns>
        Task<PagedResponse<SubscriptionResponse>?> GetSubscriptions(CancellationToken ct = default);

        /// <summary>
        /// Creates a new webhook subscription for the specified events and endpoint.
        /// </summary>
        /// <param name="request">The subscription request containing the webhook URL and event types to subscribe to.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The created subscription details including the subscription ID and secret, or null if creation failed.</returns>
        Task<SubscriptionResponse?> CreateSubscription(SubscriptionRequest request,
            CancellationToken ct = default);

        /// <summary>
        /// Updates an existing webhook subscription with new configuration.
        /// </summary>
        /// <param name="subscriptionId">The unique identifier of the subscription to update.</param>
        /// <param name="request">The updated subscription request containing new webhook URL and/or event types.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The updated subscription details, or null if the update failed.</returns>
        Task<SubscriptionResponse?> UpdateSubscription(string subscriptionId, SubscriptionRequest request,
            CancellationToken ct = default);

        /// <summary>
        /// Deletes an existing webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique identifier of the subscription to delete.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteSubscription(string subscriptionId, CancellationToken ct = default);

        /// <summary>
        /// Retrieves the history of webhook subscription events.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A paged response containing webhook subscription events, or null if none exist.</returns>
        Task<PagedResponse<SubscriptionEventResponse>?> GetSubscriptionEvents(CancellationToken ct = default);
    }
}
