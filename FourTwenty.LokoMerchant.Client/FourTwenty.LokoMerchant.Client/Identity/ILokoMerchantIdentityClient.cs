namespace FourTwenty.LokoMerchant.Client.Identity
{
    public interface ILokoMerchantIdentityClient
    {
        Task<LokoAuthResponse?> GetToken(string clientId, string clientSecret, CancellationToken ct = default);
    }
}
