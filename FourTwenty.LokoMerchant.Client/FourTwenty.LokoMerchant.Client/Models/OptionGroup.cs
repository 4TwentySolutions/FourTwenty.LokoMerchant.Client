namespace FourTwenty.LokoMerchant.Client.Models
{
    public record OptionGroup
    {
        [JsonPropertyName("externalId")]
        public required string ExternalId { get; init; }


        [JsonPropertyName("title")]
        public required string Title { get; init; }

        [JsonPropertyName("type"), JsonConverter(typeof(LowerCaseEnumConverter<OptionGroupType>))]
        public required OptionGroupType Type { get; init; }

        [JsonPropertyName("min")]
        public int? Min { get; init; }

        [JsonPropertyName("max")]
        public int? Max { get; init; }

        [JsonPropertyName("options")]
        public List<OptionInner>? Options { get; init; }
    }
}
