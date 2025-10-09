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
                case HttpStatusCode.NotFound:
                    var error = await response.Content.ReadFromJsonAsync<LokoErrorResponse>(ct);
                    throw new LokoException(error);
                case HttpStatusCode.Forbidden:
                    var rawMessage = await response.Content.ReadAsStringAsync(ct);
                    throw new LokoException(new LokoErrorResponse()
                    {
                        Message = "Access forbidden. You do not have permission to access this resource.",
                        Code = (int)HttpStatusCode.Forbidden,
                        Errors =
                        [rawMessage]
                    });
                default:
                    response.EnsureSuccessStatusCode();
                    return;
            }
        }
    }
}
