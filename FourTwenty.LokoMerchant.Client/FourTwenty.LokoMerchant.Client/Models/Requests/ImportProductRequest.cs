namespace FourTwenty.LokoMerchant.Client.Models.Requests
{
    public record ImportProductRequest
    {
        /// <summary>
        /// Company ID to import products to
        /// </summary>
        [JsonPropertyName("companyId")]
        public required string CompanyId { get; init; }

        /// <summary>
        /// List of products to import
        /// </summary>
        [JsonPropertyName("items")]
        public required List<BaseProduct> Items { get; init; }
    }
}
