namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Represents a product category in the merchant's menu structure.
    /// Categories are used to organize products and can be nested hierarchically.
    /// </summary>
    public record Category
    {
        /// <summary>
        /// The external identifier for this category, unique within the merchant's system.
        /// </summary>
        [JsonPropertyName("externalId")]
        public required string ExternalId { get; init; }

        /// <summary>
        /// The display name of the category.
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        /// <summary>
        /// The display position/order of this category relative to other categories at the same level.
        /// Lower numbers appear first.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; init; }

        /// <summary>
        /// The external identifier of the parent category if this is a subcategory.
        /// Leave null for top-level categories.
        /// </summary>
        [JsonPropertyName("parentExternalId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ParentExternalId { get; init; }

        /// <summary>
        /// The working schedule for this category, defining when items in this category are available.
        /// If not specified, the category follows the store's default schedule.
        /// </summary>
        [JsonPropertyName("workSchedule"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WorkSchedule? WorkSchedule { get; init; }
    }
}
