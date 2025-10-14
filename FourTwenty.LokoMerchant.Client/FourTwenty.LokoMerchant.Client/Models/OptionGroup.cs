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

        [JsonPropertyName("min"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Min { get; init; }

        [JsonPropertyName("max"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Max { get; init; }

        [JsonPropertyName("options")]
        public required List<OptionInner> Options { get; init; }
    }
}
