namespace FourTwenty.LokoMerchant.Client.Models
{
    public record MenuProductCategory
    {
        [JsonPropertyName("mainExternalId")]
        public required string MainExternalId { get; init; }

        [JsonPropertyName("extraExternalIds")]
        public List<string>? ExtraExternalIds { get; init; }
    }
}
