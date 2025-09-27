namespace FourTwenty.LokoMerchant.Client.Models
{
    public record MenuProductOptionGroup
    {
        [JsonPropertyName("externalId")]
        public required string ExternalId { get; init; }
        [JsonPropertyName("sortOrder")]
        public required int SortOrder { get; init; }
    }
}
