namespace FourTwenty.LokoMerchant.Client.Models
{
    /// <summary>
    /// Specifies the actor responsible for initiating a cancellation.
    /// </summary>
    public enum CancellationActor
    {
        /// <summary>
        /// The customer initiated the cancellation.
        /// </summary>
        Customer,

        /// <summary>
        /// The merchant initiated the cancellation.
        /// </summary>
        Merchant
    }
}