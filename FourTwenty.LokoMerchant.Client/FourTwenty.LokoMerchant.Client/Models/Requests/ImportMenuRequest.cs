namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    public record ImportMenuRequest
    {
        [JsonPropertyName("categories")]
        public required List<Category> Categories { get; init; }

        [JsonPropertyName("products")]
        public required List<MenuProduct> Products { get; init; }

        [JsonPropertyName("options")]
        public List<Option>? Options { get; init; }

        [JsonPropertyName("optionGroups")]
        public List<OptionGroup>? OptionGroups { get; init; }
    }
}
