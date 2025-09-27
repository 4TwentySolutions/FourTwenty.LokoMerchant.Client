namespace FourTwenty.LokoMerchant.Client.Interfaces
{
    /// <summary>
    /// Provides functionality for managing menu items, products, offers, and categories in the Loko Merchant system.
    /// </summary>
    public interface IMenuProvider
    {
        /// <summary>
        /// Imports products into the merchant's catalog.
        /// </summary>
        /// <param name="request">The product import request containing the products to be imported.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>An ID response containing the import operation ID, or null if the import failed.</returns>
        Task<IdResponse?> ImportProducts(ImportProductRequest request, CancellationToken ct = default);

        /// <summary>
        /// Imports offers (pricing and availability) for products in the merchant's catalog.
        /// </summary>
        /// <param name="request">The offers import request containing the offers to be imported.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>An ID response containing the import operation ID, or null if the import failed.</returns>
        Task<IdResponse?> ImportOffers(ImportOffersRequest request, CancellationToken ct = default);

        /// <summary>
        /// Imports categories for organizing products in the merchant's menu.
        /// </summary>
        /// <param name="companyId">The unique identifier of the company/merchant.</param>
        /// <param name="request">Collection of categories to be imported.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>An ID response containing the import operation ID, or null if the import failed.</returns>
        Task<IdResponse?> ImportCategories(string companyId, IEnumerable<Category> request,
            CancellationToken ct = default);

        /// <summary>
        /// Imports a complete menu structure including products, offers, and categories.
        /// </summary>
        /// <param name="companyId">The unique identifier of the company/merchant.</param>
        /// <param name="request">The complete menu import request containing all menu data.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>An ID response containing the import operation ID, or null if the import failed.</returns>
        Task<IdResponse?> ImportMenu(string companyId, ImportMenuRequest request, CancellationToken ct = default);

        /// <summary>
        /// Performs a partial menu import to update specific items without replacing the entire menu.
        /// </summary>
        /// <param name="request">The partial import request containing specific items to update.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>An ID response containing the import operation ID, or null if the import failed.</returns>
        Task<IdResponse?> PartialMenuImport(PartialImportRequest request, CancellationToken ct = default);
    }
}
