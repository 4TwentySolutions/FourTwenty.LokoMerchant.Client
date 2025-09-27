namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record SubscriptionEventResponse
    {
        [JsonPropertyName("name"), JsonConverter(typeof(WebhookEventJsonConverter))]
        public WebhookEvent? Name { get; init; }

        [JsonPropertyName("description")]
        public string? Description { get; init; }
    }
}
