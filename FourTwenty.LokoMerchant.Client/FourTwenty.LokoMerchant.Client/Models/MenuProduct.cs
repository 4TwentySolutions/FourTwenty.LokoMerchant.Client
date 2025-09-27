namespace FourTwenty.LokoMerchant.Client.Models
{
    public record MenuProduct : BaseProduct
    {
        [JsonPropertyName("categories")]
        public required MenuProductCategory Categories { get; init; }

        [JsonPropertyName("optionGroups")]
        public List<MenuProductOptionGroup>? OptionGroups { get; init; }

        [JsonPropertyName("offers")]
        public required List<MenuOffer> Offers { get; init; }
    }
}
