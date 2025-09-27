namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    public record SubscriptionRequest
    {

        [JsonPropertyName("companyIds")]
        public List<string>? CompanyIds { get; init; }

        [JsonPropertyName("events"), JsonConverter(typeof(WebhookEventJsonConverter))]
        public List<WebhookEvent>? Events { get; init; }

        [JsonPropertyName("callback")]
        public string? Callback { get; init; }
    }
}
