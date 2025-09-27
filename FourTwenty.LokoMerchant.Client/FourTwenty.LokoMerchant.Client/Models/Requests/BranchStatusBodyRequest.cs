namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    public record BranchStatusBodyRequest
    {
        [JsonPropertyName("till"), JsonConverter(typeof(TimestampJsonConverter))]
        public long? Till { get; init; }
    }
}
