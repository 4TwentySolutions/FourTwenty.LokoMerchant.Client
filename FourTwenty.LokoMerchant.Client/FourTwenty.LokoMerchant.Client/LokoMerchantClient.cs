using FourTwenty.LokoMerchant.Client.Providers;

namespace FourTwenty.LokoMerchant.Client
{
    public class LokoMerchantClient(HttpClient httpClient) : ILokoMerchantClient
    {
        public IStoreProvider Store => new StoreProvider(httpClient);

        public IWebhooksProvider Webhooks => new WebhooksProvider(httpClient);

    }
}
