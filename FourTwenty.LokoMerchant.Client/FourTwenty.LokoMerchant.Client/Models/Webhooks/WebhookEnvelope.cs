namespace FourTwenty.LokoMerchant.Client.Models.Webhooks;

/// <summary>
/// Represents the envelope structure for webhook payloads received from the Loko Merchant API.
/// </summary>
/// <typeparam name="T">The type of the webhook data payload.</typeparam>
public record WebhookEnvelope<T>
{
    /// <summary>
    /// The event type identifier (e.g., "order.new", "order.status.changed").
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; init; }

    /// <summary>
    /// The webhook payload data specific to the event type.
    /// </summary>
    [JsonPropertyName("data")]
    public T? Data { get; init; }

    /// <summary>
    /// The signature for verifying the authenticity of the webhook payload.
    /// </summary>
    [JsonPropertyName("signature")]
    public required string Signature { get; init; }
}
