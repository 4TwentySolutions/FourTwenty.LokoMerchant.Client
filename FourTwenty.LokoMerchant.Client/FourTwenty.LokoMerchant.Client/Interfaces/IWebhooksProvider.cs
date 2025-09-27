namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    public interface IWebhooksProvider
    {
        Task<PagedResponse<SubscriptionResponse>?> GetSubscriptions(CancellationToken ct = default);

        Task<SubscriptionResponse?> CreateSubscription(SubscriptionRequest request,
            CancellationToken ct = default);

        Task<SubscriptionResponse?> UpdateSubscription(string subscriptionId, SubscriptionRequest request,
            CancellationToken ct = default);

        Task DeleteSubscription(string subscriptionId, CancellationToken ct = default);
        Task<PagedResponse<SubscriptionEventResponse>?> GetSubscriptionEvents(CancellationToken ct = default);
    }
}
