namespace FourTwenty.LokoMerchant.Client.Models.Webhooks;

/// <summary>
/// Represents webhook data for store availability changes.
/// </summary>
public record StoreAvailabilityChangedWebhookData
{
    /// <summary>
    /// The unique identifier of the store.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Company information associated with the store.
    /// </summary>
    [JsonPropertyName("company")]
    public required Company Company { get; init; }

    /// <summary>
    /// The availability status of the store.
    /// </summary>
    [JsonPropertyName("availability")]
    public required Availability Availability { get; init; }
}

/// <summary>
/// Represents company information in webhook payloads.
/// </summary>
public record Company
{
    /// <summary>
    /// The unique identifier of the company.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}

/// <summary>
/// Represents store availability status.
/// </summary>
public record Availability
{
    /// <summary>
    /// Indicates whether the store is currently open for orders.
    /// </summary>
    [JsonPropertyName("open")]
    public required bool Open { get; init; }
}
