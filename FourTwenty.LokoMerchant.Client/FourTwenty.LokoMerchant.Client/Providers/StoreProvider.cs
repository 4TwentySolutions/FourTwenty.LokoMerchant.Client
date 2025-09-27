namespace FourTwenty.LokoMerchant.Client.Providers
{
    internal sealed class StoreProvider(HttpClient httpClient) : IStoreProvider
    {
        /// <summary>
        /// Pause or unpause a branch (store).
        /// </summary>
        /// <param name="storeId">The ID of the store to update.</param>
        /// <param name="status">The new status for the store.</param>
        /// <param name="request">Optional. The request body containing the new status details.</param>
        /// <param name="ct">Optional. A cancellation token to cancel the operation.</param>
        /// <returns></returns>
        public async Task UpdateStatus(string storeId, StoreStatus status, BranchStatusBodyRequest request, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"/v1/merchant/stores/{storeId}/schedule/{status}", request, cancellationToken: ct);
            if (response.IsSuccessStatusCode) return;

            await ErrorHandlingHelper.HandleError(response, ct);
        }

        /// <summary>
        /// Update the schedule for a specific store.
        /// </summary>
        /// <param name="storeId">The ID of the store to update.</param>
        /// <param name="schedules">The new schedule for the store.</param>
        /// <param name="ct">Optional. A cancellation token to cancel the operation.</param>
        /// <returns></returns>
        public async Task UpdateSchedule(string storeId, IEnumerable<BranchDaySchedule> schedules, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"/v1/merchant/stores/{storeId}/schedule", schedules, cancellationToken: ct);
            if (response.IsSuccessStatusCode) return;
            await ErrorHandlingHelper.HandleError(response, ct);
        }

        /// <summary>
        /// Update the schedules for multiple stores.
        /// </summary>
        /// <param name="schedules">The new schedules for the stores.</param>
        /// <param name="ct">Optional. A cancellation token to cancel the operation.</param>
        /// <returns></returns>
        public async Task UpdateStoresSchedule(IEnumerable<BranchDayStoreSchedule> schedules,
            CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"/v1/merchant/schedule", schedules, cancellationToken: ct);
            if (response.IsSuccessStatusCode) return;
            await ErrorHandlingHelper.HandleError(response, ct);
        }
    }
}
