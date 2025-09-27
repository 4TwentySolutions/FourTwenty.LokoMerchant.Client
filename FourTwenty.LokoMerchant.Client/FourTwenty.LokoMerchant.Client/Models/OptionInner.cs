namespace FourTwenty.LokoMerchant.Client.Models
{
    public record OptionInner
    {
        [JsonPropertyName("sku")]
        public required string Sku { get; init; }
        [JsonPropertyName("sortOrder")]
        public required int SortOrder { get; init; }
        [JsonPropertyName("max")]
        public int? Max { get; init; }
    }
}
