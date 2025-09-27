namespace FourTwenty.LokoMerchant.Client.Helpers
{
    public static class ErrorHandlingHelper
    {
        public static async Task HandleError(HttpResponseMessage response, CancellationToken ct)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                    var error = await response.Content.ReadFromJsonAsync<LokoErrorResponse>(ct);
                    throw new LokoException(error);
                default:
                    response.EnsureSuccessStatusCode();
                    return;
            }
        }
    }
}
