namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    public interface IStoreProvider
    {
        Task UpdateStatus(string storeId, StoreStatus status, BranchStatusBodyRequest request,
            CancellationToken ct = default);
        Task UpdateSchedule(string storeId, IEnumerable<BranchDaySchedule> schedules, CancellationToken ct = default);

        Task UpdateStoresSchedule(IEnumerable<BranchDayStoreSchedule> schedules,
            CancellationToken ct = default);
    }
}
