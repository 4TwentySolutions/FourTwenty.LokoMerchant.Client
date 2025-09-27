namespace FourTwenty.LokoMerchant.Client
{
    public record LokoMerchantConfig
    {
        public required string ClientId { get; init; }
        public required string ClientSecret { get; init; }
    }
}
