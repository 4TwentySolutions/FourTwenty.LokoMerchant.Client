namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Represents the operational status that can be applied to a store.
    /// </summary>
    public enum StoreStatus
    {
        /// <summary>
        /// Pauses the store, making it temporarily unavailable for new orders.
        /// </summary>
        Pause,

        /// <summary>
        /// Unpauses the store, making it available for new orders.
        /// </summary>
        Unpause
    }
}
