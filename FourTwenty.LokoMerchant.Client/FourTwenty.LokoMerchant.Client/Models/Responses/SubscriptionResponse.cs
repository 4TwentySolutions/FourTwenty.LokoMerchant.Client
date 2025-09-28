namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    /// <summary>
    /// Response containing webhook subscription details including the subscription ID and secret.
    /// Extends the subscription request with server-generated fields.
    /// </summary>
    public record SubscriptionResponse : SubscriptionRequest
    {
        /// <summary>
        /// The unique identifier assigned to this webhook subscription.
        /// Use this ID for updating or deleting the subscription.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        /// <summary>
        /// The secret key used for webhook signature verification.
        /// Use this to verify that incoming webhooks are authentic.
        /// </summary>
        [JsonPropertyName("secret")]
        public string? Secret { get; init; }

    }
}
