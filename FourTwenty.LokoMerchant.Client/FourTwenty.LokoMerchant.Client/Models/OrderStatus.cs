namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Represents the status of an order in the Loko Merchant system.
    /// This is a value type that provides type safety while allowing for custom/unknown status values.
    /// </summary>
    [JsonConverter(typeof(OrderStatusJsonConverter))]
    public readonly struct OrderStatus(string? value) : IEquatable<OrderStatus>
    {
        /// <summary>
        /// The string value of the order status.
        /// </summary>
        public string Value { get; } = value ?? string.Empty;

        /// <summary>
        /// The order is newly created and not yet processed.
        /// </summary>
        public static readonly OrderStatus New = new("new");

        /// <summary>
        /// The order is being prepared.
        /// </summary>
        public static readonly OrderStatus Preparation = new("preparation");

        /// <summary>
        /// The order is ready for delivery.
        /// </summary>
        public static readonly OrderStatus ReadyForDelivery = new("ready_for_delivery");

        /// <summary>
        /// The order is currently being delivered.
        /// </summary>
        public static readonly OrderStatus DeliveryInProgress = new("delivery_in_progress");

        /// <summary>
        /// The order has been delivered.
        /// </summary>
        public static readonly OrderStatus Delivered = new("delivered");

        /// <summary>
        /// The order has been canceled.
        /// </summary>
        public static readonly OrderStatus Canceled = new("canceled");

        /// <summary>
        /// The order has been partially fulfilled.
        /// </summary>
        public static readonly OrderStatus PartialFulfilment = new("partial_fulfilment");

        /// <summary>
        /// A cancellation of the order has been requested.
        /// </summary>
        public static readonly OrderStatus RequestCancellation = new("request_cancellation");

        /// <summary>
        /// Determines whether this order status equals another order status.
        /// </summary>
        /// <param name="other">The other order status to compare with.</param>
        /// <returns>True if the statuses are equal; otherwise, false.</returns>
        public bool Equals(OrderStatus other) => Value == other.Value;

        /// <summary>
        /// Determines whether this order status equals the specified object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>True if the object is an OrderStatus and equals this status; otherwise, false.</returns>
        public override bool Equals(object? obj) => obj is OrderStatus other && Equals(other);

        /// <summary>
        /// Returns the hash code for this order status.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Implicitly converts an OrderStatus to its string representation.
        /// </summary>
        /// <param name="status">The order status to convert.</param>
        /// <returns>The string value of the order status.</returns>
        public static implicit operator string(OrderStatus status) => status.Value;

        /// <summary>
        /// Implicitly converts a string to an OrderStatus.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>An OrderStatus with the specified value.</returns>
        public static implicit operator OrderStatus(string value) => new(value);

        /// <summary>
        /// Returns the string representation of the order status.
        /// </summary>
        /// <returns>The string value of the order status.</returns>
        public override string ToString() => Value;
    }
}
