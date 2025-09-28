namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    /// <summary>
    /// Provides functionality for managing store operations including status updates and scheduling.
    /// </summary>
    public interface IStoreProvider
    {
        /// <summary>
        /// Updates the operational status of a specific store.
        /// </summary>
        /// <param name="storeId">The unique identifier of the store to update.</param>
        /// <param name="status">The new status to set for the store (Pause or Unpause).</param>
        /// <param name="request">Additional request parameters for the status update.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateStatus(string storeId, StoreStatus status, BranchStatusBodyRequest request,
            CancellationToken ct = default);

        /// <summary>
        /// Updates the schedule for a specific store with the provided day schedules.
        /// </summary>
        /// <param name="storeId">The unique identifier of the store to update.</param>
        /// <param name="schedules">Collection of branch day schedules to apply to the store.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateSchedule(string storeId, IEnumerable<BranchDaySchedule> schedules, CancellationToken ct = default);

        /// <summary>
        /// Updates schedules for multiple stores simultaneously.
        /// </summary>
        /// <param name="schedules">Collection of branch day store schedules containing store IDs and their respective schedules.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateStoresSchedule(IEnumerable<BranchDayStoreSchedule> schedules,
            CancellationToken ct = default);
    }
}
