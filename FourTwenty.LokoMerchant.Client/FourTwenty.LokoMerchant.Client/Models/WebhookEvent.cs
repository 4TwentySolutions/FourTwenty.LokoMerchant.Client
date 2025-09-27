namespace FourTwenty.LokoMerchant.Client.Models
{
    public readonly struct WebhookEvent(string? value) : IEquatable<WebhookEvent>
    {
        public string Value { get; } = value ?? string.Empty;

        public static readonly WebhookEvent OrderNew = new("order.new");
        public static readonly WebhookEvent OrderItemChanged = new("order.item.changed");
        public static readonly WebhookEvent OrderStatusChanged = new("order.status.changed");
        public static readonly WebhookEvent OrderCourierAssigned = new("order.courier.assigned");

        public bool Equals(WebhookEvent other) => Value == other.Value;
        public override bool Equals(object? obj) => obj is WebhookEvent other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator string(WebhookEvent webhookEvent) => webhookEvent.Value;
        public static implicit operator WebhookEvent(string value) => new(value);
    }
}
