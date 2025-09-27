namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record SubscriptionResponse : SubscriptionRequest
    {
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        [JsonPropertyName("secret")]
        public string? Secret { get; init; }

    }
}
