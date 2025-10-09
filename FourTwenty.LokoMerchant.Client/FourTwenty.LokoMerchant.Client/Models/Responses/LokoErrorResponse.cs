namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record LokoErrorResponse
    {

        [JsonPropertyName("error")]
        public string? Error { get; init; }

        [JsonPropertyName("message")]
        public string? Message { get; init; }

        [JsonPropertyName("code")]
        public int? Code { get; init; }

        [JsonPropertyName("errors")]
        public string[]? Errors { get; init; }
    }
}
