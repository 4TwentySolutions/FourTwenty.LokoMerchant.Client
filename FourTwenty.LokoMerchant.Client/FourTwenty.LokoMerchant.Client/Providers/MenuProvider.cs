namespace FourTwenty.LokoMerchant.Client.Providers
{
    internal class MenuProvider(HttpClient httpClient) : IMenuProvider
    {

        public async Task<IdResponse?> ImportProducts(ImportProductRequest request, CancellationToken ct = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"v1/merchant/import/products", content, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> ImportOffers(ImportOffersRequest request, CancellationToken ct = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"v1/merchant/import/offers", content, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> ImportCategories(string companyId, IEnumerable<Category> request, CancellationToken ct = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"v1/merchant/companies/{companyId}/import/categories", content, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> ImportMenu(string companyId, ImportMenuRequest request, CancellationToken ct = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"v1/merchant/companies/{companyId}/import", content, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<IdResponse?> PartialMenuImport(PartialImportRequest request, CancellationToken ct = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PatchAsync($"v1/merchant/import/part-offers", content, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IdResponse>(ct);
            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

    }
}
