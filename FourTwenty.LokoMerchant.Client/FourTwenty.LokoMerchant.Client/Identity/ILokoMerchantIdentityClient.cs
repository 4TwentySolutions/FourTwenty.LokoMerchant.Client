namespace FourTwenty.LokoMerchant.Client.Identity
{
    /// <summary>
    /// Client interface for authenticating with the Loko Merchant identity server using OAuth 2.0 client credentials flow.
    /// </summary>
    public interface ILokoMerchantIdentityClient
    {
        /// <summary>
        /// Authenticates with the identity server and retrieves an access token using client credentials.
        /// </summary>
        /// <param name="clientId">The OAuth 2.0 client identifier.</param>
        /// <param name="clientSecret">The OAuth 2.0 client secret.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>An authentication response containing the access token and expiration information, or null if authentication failed.</returns>
        Task<LokoAuthResponse?> GetToken(string clientId, string clientSecret, CancellationToken ct = default);
    }
}
