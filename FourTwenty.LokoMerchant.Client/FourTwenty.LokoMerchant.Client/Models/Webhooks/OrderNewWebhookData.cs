namespace FourTwenty.LokoMerchant.Client.Models.Webhooks;

/// <summary>
/// Represents webhook data for new order events.
/// </summary>
public record OrderNewWebhookData
{
    /// <summary>
    /// The unique identifier of the order.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// The human-readable order number.
    /// </summary>
    [JsonPropertyName("number")]
    public string? Number { get; init; }

    /// <summary>
    /// The unique identifier of the store where the order was placed.
    /// </summary>
    [JsonPropertyName("storeId")]
    public string? StoreId { get; init; }

    /// <summary>
    /// The current status of the order.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The list price of the order before any discounts.
    /// </summary>
    [JsonPropertyName("listPrice")]
    public OrderPriceResponse? ListPrice { get; init; }

    /// <summary>
    /// The net price of the order after discounts.
    /// </summary>
    [JsonPropertyName("netPrice")]
    public OrderPriceResponse? NetPrice { get; init; }

    /// <summary>
    /// Optional comment or note from the customer.
    /// </summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; init; }

    /// <summary>
    /// Estimated cooking time in minutes.
    /// </summary>
    [JsonPropertyName("estimatedCookingTime")]
    public int? EstimatedCookingTime { get; init; }

    /// <summary>
    /// The list of items in the order.
    /// </summary>
    [JsonPropertyName("items")]
    public List<OrderItemResponse>? Items { get; init; }

    /// <summary>
    /// Customer information.
    /// </summary>
    [JsonPropertyName("customer")]
    public OrderCustomerResponse? Customer { get; init; }

    /// <summary>
    /// Courier information if assigned.
    /// </summary>
    [JsonPropertyName("courier")]
    public OrderCourierResponse? Courier { get; init; }

    /// <summary>
    /// List of promotions applied to the order.
    /// </summary>
    [JsonPropertyName("promos")]
    public List<OrderPromoResponse>? Promos { get; init; }

    /// <summary>
    /// The timestamp when the order was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; init; }

    /// <summary>
    /// The timestamp when the order was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; init; }

    /// <summary>
    /// Indicates whether this is a test order.
    /// </summary>
    [JsonPropertyName("isTest")]
    public bool? IsTest { get; init; }
}

/// <summary>
/// Represents a promotional offer applied to an order in webhook payloads.
/// Uses JsonExtensionData to capture all fields dynamically until the exact structure is known.
/// </summary>
public record OrderPromoResponse
{
    /// <summary>
    /// Captures any additional fields from the webhook payload that are not explicitly mapped.
    /// Access promo data via this dictionary until the full structure is defined.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}
