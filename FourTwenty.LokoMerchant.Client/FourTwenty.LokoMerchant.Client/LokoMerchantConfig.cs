namespace FourTwenty.LokoMerchant.Client
{
    /// <summary>
    /// Configuration settings for the Loko Merchant API client.
    /// Contains the OAuth 2.0 client credentials required for API authentication.
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
    }
}
