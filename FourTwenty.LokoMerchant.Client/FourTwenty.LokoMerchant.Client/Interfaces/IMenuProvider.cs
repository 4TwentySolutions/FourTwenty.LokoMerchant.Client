namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    public interface IMenuProvider
    {
        Task<IdResponse?> ImportProducts(ImportProductRequest request, CancellationToken ct = default);
        Task<IdResponse?> ImportOffers(ImportOffersRequest request, CancellationToken ct = default);

        Task<IdResponse?> ImportCategories(string companyId, IEnumerable<Category> request,
            CancellationToken ct = default);

        Task<IdResponse?> ImportMenu(string companyId, ImportMenuRequest request, CancellationToken ct = default);

        Task<IdResponse?> PartialMenuImport(PartialImportRequest request, CancellationToken ct = default);
    }
}
