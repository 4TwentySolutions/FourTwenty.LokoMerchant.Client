namespace FourTwenty.LokoMerchant.Client
{
    /// <summary>
    /// Configuration settings for the Loko Merchant API client.
    /// Contains the OAuth 2.0 client credentials and service endpoints required for API authentication.
    /// </summary>
    public record LokoMerchantConfig
    {
        /// <summary>
        /// The OAuth 2.0 client identifier provided by Loko Merchant.
        /// This is used for authentication when obtaining access tokens.
        /// </summary>
        public required string ClientId { get; init; }

        /// <summary>
        /// The OAuth 2.0 client secret provided by Loko Merchant.
        /// This should be stored securely and never exposed in client-side code.
        /// </summary>
        public required string ClientSecret { get; init; }

        /// <summary>
        /// The base URL for the Loko Merchant identity server.
        /// Used for OAuth 2.0 token authentication.
        /// Defaults to the production identity server URL.
        /// </summary>
        public string IdentityBaseUrl { get; init; } = "https://identity.loko-merchant.com/";

        /// <summary>
        /// The base URL for the Loko Merchant API server.
        /// Used for all merchant API operations.
        /// Defaults to the production API server URL.
        /// </summary>
        public string ApiBaseUrl { get; init; } = "https://api.loko-merchant.com/";
    }
}
