namespace FourTwenty.LokoMerchant.Client.Providers
{
    internal class WebhooksProvider(HttpClient httpClient) : IWebhooksProvider
    {
        /// <summary>
        /// Get all webhook subscriptions.
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of webhook subscriptions</returns>
        public async Task<PagedResponse<SubscriptionResponse>?> GetSubscriptions(CancellationToken ct = default)
        {
            var response = await httpClient.GetAsync($"v1/merchant/callback/subscriptions", ct);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<PagedResponse<SubscriptionResponse>>(
                    cancellationToken: ct);

            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        /// <summary>
        /// Create a new webhook subscription.
        /// </summary>
        /// <param name="request">The subscription request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The created subscription response</returns>
        public async Task<SubscriptionResponse?> CreateSubscription(SubscriptionRequest request,
            CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"v1/merchant/callback/subscriptions", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<SubscriptionResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        /// <summary>
        /// Update an existing webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to update</param>
        /// <param name="request">The updated subscription request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The updated subscription response</returns>
        public async Task<SubscriptionResponse?> UpdateSubscription(string subscriptionId, SubscriptionRequest request,
            CancellationToken ct = default)
        {
            var response =
                await httpClient.PutAsJsonAsync($"v1/merchant/callback/subscriptions/{subscriptionId}", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<SubscriptionResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }


        /// <summary>
        /// Delete a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to delete</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task DeleteSubscription(string subscriptionId, CancellationToken ct = default)
        {
            var response = await httpClient.DeleteAsync($"v1/merchant/callback/subscriptions/{subscriptionId}", ct);
            if (response.IsSuccessStatusCode) return;
            await ErrorHandlingHelper.HandleError(response, ct);
        }

        /// <summary>
        /// Get all webhook subscription events.
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of subscription events</returns>
        public async Task<PagedResponse<SubscriptionEventResponse>?> GetSubscriptionEvents(CancellationToken ct = default)
        {
            var response = await httpClient.GetAsync($"v1/merchant/callback/events", ct);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<PagedResponse<SubscriptionEventResponse>>(
                    cancellationToken: ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;

        }
    }
}
