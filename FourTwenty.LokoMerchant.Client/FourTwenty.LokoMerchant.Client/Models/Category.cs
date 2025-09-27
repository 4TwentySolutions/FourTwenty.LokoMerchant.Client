namespace FourTwenty.LokoMerchant.Client.Models
{
    public record Category
    {
        [JsonPropertyName("externalId")]
        public required string ExternalId { get; init; }
        [JsonPropertyName("name")]
        public required string Name { get; init; }
        [JsonPropertyName("position")]
        public int? Position { get; init; }
        [JsonPropertyName("parentExternalId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ParentExternalId { get; init; }

        [JsonPropertyName("workSchedule"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WorkSchedule? WorkSchedule { get; init; }
    }
}
