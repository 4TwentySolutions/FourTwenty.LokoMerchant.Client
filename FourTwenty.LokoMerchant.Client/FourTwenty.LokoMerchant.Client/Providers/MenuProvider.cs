namespace FourTwenty.LokoMerchant.Client.Providers
{
    internal class MenuProvider(HttpClient httpClient) : IMenuProvider
    {

        public async Task<IdResponse?> ImportProducts(ImportProductRequest request, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"v1/merchant/import/products", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> ImportOffers(ImportOffersRequest request, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"v1/merchant/import/offers", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> ImportCategories(string companyId, IEnumerable<Category> request, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"v1/merchant/companies/{companyId}/import/categories", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> ImportMenu(string companyId, ImportMenuRequest request, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"v1/merchant/companies/{companyId}/import", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> PartialMenuImport(PartialImportRequest request, CancellationToken ct = default)
        {
            var response = await httpClient.PatchAsJsonAsync($"v1/merchant/import/part-offers", request, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

    }
}
