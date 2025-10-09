namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    /// <summary>
    /// Request model for creating or updating webhook subscriptions.
    /// Defines which events to subscribe to and where to send the webhooks.
    /// </summary>
    public record SubscriptionRequest
    {
        /// <summary>
        /// List of company IDs to subscribe to events for.
        /// If not specified, subscribes to events for all accessible companies.
        /// </summary>
        [JsonPropertyName("companyIds")]
        public List<string>? CompanyIds { get; init; }

        /// <summary>
        /// List of webhook events to subscribe to.
        /// Determines which types of events will trigger webhook notifications.
        /// </summary>
        [JsonPropertyName("events")]
        public List<WebhookEvent>? Events { get; init; }

        /// <summary>
        /// The URL endpoint where webhook notifications will be sent.
        /// Must be a valid HTTPS URL that can receive POST requests.
        /// </summary>
        [JsonPropertyName("callback")]
        public string? Callback { get; init; }
    }
}
