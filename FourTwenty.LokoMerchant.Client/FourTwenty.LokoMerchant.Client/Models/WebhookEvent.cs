namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Represents different types of webhook events that can be subscribed to in the Loko Merchant system.
    /// This is a value type that provides type safety while allowing for custom event types.
    /// </summary>
    public readonly struct WebhookEvent(string? value) : IEquatable<WebhookEvent>
    {
        /// <summary>
        /// The string value of the webhook event type.
        /// </summary>
        public string Value { get; } = value ?? string.Empty;

        /// <summary>
        /// Triggered when a new order is created.
        /// </summary>
        public static readonly WebhookEvent OrderNew = new("order.new");

        /// <summary>
        /// Triggered when an item in an order is modified.
        /// </summary>
        public static readonly WebhookEvent OrderItemChanged = new("order.item.changed");

        /// <summary>
        /// Triggered when the status of an order changes (e.g., confirmed, preparing, ready, delivered).
        /// </summary>
        public static readonly WebhookEvent OrderStatusChanged = new("order.status.changed");

        /// <summary>
        /// Triggered when a courier is assigned to deliver an order.
        /// </summary>
        public static readonly WebhookEvent OrderCourierAssigned = new("order.courier.assigned");

        /// <summary>
        /// Determines whether this webhook event equals another webhook event.
        /// </summary>
        /// <param name="other">The other webhook event to compare with.</param>
        /// <returns>True if the events are equal; otherwise, false.</returns>
        public bool Equals(WebhookEvent other) => Value == other.Value;

        /// <summary>
        /// Determines whether this webhook event equals the specified object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>True if the object is a WebhookEvent and equals this event; otherwise, false.</returns>
        public override bool Equals(object? obj) => obj is WebhookEvent other && Equals(other);

        /// <summary>
        /// Returns the hash code for this webhook event.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Implicitly converts a WebhookEvent to its string representation.
        /// </summary>
        /// <param name="webhookEvent">The webhook event to convert.</param>
        /// <returns>The string value of the webhook event.</returns>
        public static implicit operator string(WebhookEvent webhookEvent) => webhookEvent.Value;

        /// <summary>
        /// Implicitly converts a string to a WebhookEvent.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>A WebhookEvent with the specified value.</returns>
        public static implicit operator WebhookEvent(string value) => new(value);
    }
}
