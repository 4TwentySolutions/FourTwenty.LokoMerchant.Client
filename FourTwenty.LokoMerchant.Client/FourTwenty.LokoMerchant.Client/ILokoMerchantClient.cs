namespace FourTwenty.LokoMerchant.Client
{
    /// <summary>
    /// Main client interface for interacting with the Loko Merchant API.
    /// Provides access to store management and webhook functionality.
    /// </summary>
    public interface ILokoMerchantClient
    {
        /// <summary>
        /// Gets the store provider for managing store operations such as status updates and scheduling.
        /// </summary>
        IStoreProvider Store { get; }

        /// <summary>
        /// Gets the webhooks provider for managing webhook subscriptions and events.
        /// </summary>
        IWebhooksProvider Webhooks { get; }
    }
}
