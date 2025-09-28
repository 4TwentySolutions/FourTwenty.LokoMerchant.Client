
namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    /// <summary>
    /// Provides functionality for obtaining and managing bearer tokens for API authentication.
    /// </summary>
    public interface IBearerTokenProvider
    {
        /// <summary>
        /// Retrieves a valid bearer token for API authentication.
        /// This method handles token caching and automatic renewal as needed.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A valid bearer token string that can be used in the Authorization header.</returns>
        Task<string> GetToken(CancellationToken ct = default);
    }
}
