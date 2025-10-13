namespace FourTwenty.LokoMerchant.Client.Providers
{
    internal class OrdersProvider(HttpClient httpClient) : IOrdersProvider
    {
        public async Task<PagedResponse<OrderResponse>?> GetOrders(GetOrdersRequest request, CancellationToken ct = default)
        {
            var query = BuildQueryString(request);
            var url = "v1/merchant/orders" + query;
            var response = await httpClient.GetAsync(url, ct);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<PagedResponse<OrderResponse>>(cancellationToken: ct);

            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task<OrderResponse?> GetOrder(string orderId, CancellationToken ct = default)
        {
            var response = await httpClient.GetAsync($"v1/merchant/orders/{orderId}", ct);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<OrderResponse>(cancellationToken: ct);

            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }

        public async Task UpdateOrderStatus(string orderId, UpdateOrderStatusRequest request, CancellationToken ct = default)
        {
            var response = await httpClient.PatchAsJsonAsync($"v1/merchant/orders/{orderId}/status-change", request, ct);
            if (response.IsSuccessStatusCode) return;
            await ErrorHandlingHelper.HandleError(response, ct);
        }

        /// <summary>
        /// Builds a query string from the provided <see cref="GetOrdersRequest"/>.
        /// </summary>
        /// <param name="request">The request containing filter and query parameters.</param>
        /// <returns>A query string for the API request.</returns>
        private static string BuildQueryString(GetOrdersRequest request)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (request.BranchIds is not null)
                foreach (var id in request.BranchIds)
                    query.Add("filter[branchIds][]", id);

            if (request.Statuses is not null)
                foreach (var status in request.Statuses)
                    query.Add("filter[status][]", status.ToString());

            if (request.CreatedAtFrom.HasValue)
                query.Add("filter[createdAt][from]", request.CreatedAtFrom.Value.ToString());

            if (request.CreatedAtTo.HasValue)
                query.Add("filter[createdAt][to]", request.CreatedAtTo.Value.ToString());

            if (request.Sort is not null)
                foreach (var sort in request.Sort)
                    query.Add("sort[]", sort);

            if (request.Offset.HasValue)
                query.Add("offset", request.Offset.Value.ToString());

            if (request.Limit.HasValue)
                query.Add("limit", request.Limit.Value.ToString());

            var queryString = query.ToString();
            return string.IsNullOrEmpty(queryString) ? string.Empty : "?" + queryString;
        }
    }
}
