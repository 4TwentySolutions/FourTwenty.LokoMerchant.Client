
namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    public interface IBearerTokenProvider
    {
        Task<string> GetToken(CancellationToken ct = default);
    }
}
