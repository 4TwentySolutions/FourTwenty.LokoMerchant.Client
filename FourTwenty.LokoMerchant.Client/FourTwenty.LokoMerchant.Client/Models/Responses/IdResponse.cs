namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record IdResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; init; }
    }
}
