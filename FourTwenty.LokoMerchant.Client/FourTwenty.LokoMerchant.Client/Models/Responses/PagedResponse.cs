namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record PagedResponse<T>
    {
        [JsonPropertyName("total")]
        public int? Total { get; init; }

        [JsonPropertyName("items")]
        public List<T>? Items { get; init; }
    }
}
