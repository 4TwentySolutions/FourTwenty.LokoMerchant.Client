namespace FourTwenty.LokoMerchant.Client
{
    public interface ILokoMerchantClient
    {
        IStoreProvider Store { get; }
        IWebhooksProvider Webhooks { get; }
    }
}
