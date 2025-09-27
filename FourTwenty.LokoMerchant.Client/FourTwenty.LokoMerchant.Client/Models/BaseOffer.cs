namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BaseOffer
    {
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("listPrice")]
        public required decimal ListPrice { get; init; }

        /// <summary>
        /// Old price, for showing discounts
        /// </summary>
        [JsonPropertyName("oldPrice")]
        public decimal? OldPrice { get; init; }

        /// <summary>
        /// Stock available
        /// </summary>
        [JsonPropertyName("stock")]
        public required int Stock { get; init; }

        /// <summary>
        /// Status of the offer
        /// </summary>
        [JsonPropertyName("status"), JsonConverter(typeof(JsonStringEnumConverter<OfferStatus>))]
        public OfferStatus? Status { get; init; }
    }
}
