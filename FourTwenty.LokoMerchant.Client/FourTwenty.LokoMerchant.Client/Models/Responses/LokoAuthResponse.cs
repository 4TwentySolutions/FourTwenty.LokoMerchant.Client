namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record LokoAuthResponse
    {

        /// <summary>
        /// Access token to be used in the Authorization header for subsequent requests
        /// </summary>
        [JsonPropertyName("access_token")]
        public required string AccessToken { get; init; }

        /// <summary>
        /// Time in seconds until the token expires
        /// </summary>
        [JsonPropertyName("expires_in")]
        public required int Expires { get; init; }

        /// <summary>
        /// Token type, should be "Bearer"
        /// </summary>
        [JsonPropertyName("token_type")]
        public required string TokenType { get; init; }

        /// <summary>
        /// Scope of the access token
        /// </summary>
        [JsonPropertyName("scope")]
        public required string Scope { get; init; }

    }
}
