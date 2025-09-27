
namespace FourTwenty.LokoMerchant.Client.Models
{
    public record Product : BaseProduct
    {
        [JsonPropertyName("category")]
        public required string Category { get; init; }
        [JsonPropertyName("categories")]
        public List<string>? Categories { get; init; }
    }
}
