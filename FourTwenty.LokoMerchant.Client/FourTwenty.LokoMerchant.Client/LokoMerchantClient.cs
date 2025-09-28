using FourTwenty.LokoMerchant.Client.Providers;

namespace FourTwenty.LokoMerchant.Client
{
    /// <summary>
    /// Default implementation of the Loko Merchant API client.
    /// Provides access to all API functionality through dedicated providers.
    /// </summary>
    /// <param name="httpClient">Configured HTTP client for making API requests. Should include base address and authentication.</param>
    public class LokoMerchantClient(HttpClient httpClient) : ILokoMerchantClient
    {
        /// <summary>
        /// Gets the store provider for managing store operations such as status updates and scheduling.
        /// </summary>
        public IStoreProvider Store => new StoreProvider(httpClient);

        /// <summary>
        /// Gets the webhooks provider for managing webhook subscriptions and events.
        /// </summary>
        public IWebhooksProvider Webhooks => new WebhooksProvider(httpClient);

        /// <summary>
        /// Gets the menu provider for managing menu items, products, offers, and categories.
        /// </summary>
        public IMenuProvider Menu => new MenuProvider(httpClient);

    }
}
