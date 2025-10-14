namespace FourTwenty.LokoMerchant.Client.Helpers
{
    /// <summary>
    /// Provides error handling utilities for HTTP responses from the Loko Merchant API.
    /// </summary>
    public static class ErrorHandlingHelper
    {
        /// <summary>
        /// Handles HTTP error responses by deserializing error details and throwing appropriate exceptions.
        /// </summary>
        /// <param name="response">The HTTP response message to process.</param>
        /// <param name="ct">Cancellation token for async operations.</param>
        /// <exception cref="LokoException">Thrown when the response indicates a client or server error with structured error details.</exception>
        /// <remarks>
        /// Handles the following HTTP status codes with custom error messages:
        /// <list type="bullet">
        /// <item><description>BadRequest (400): Deserializes and throws structured error response</description></item>
        /// <item><description>Unauthorized (401): Deserializes and throws structured error response</description></item>
        /// <item><description>Forbidden (403): Creates custom error message for access denial</description></item>
        /// <item><description>NotFound (404): Deserializes and throws structured error response</description></item>
        /// <item><description>Other codes: Calls EnsureSuccessStatusCode() for standard HTTP error handling</description></item>
        /// </list>
        /// </remarks>
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
                        Errors = new Dictionary<string, string[]>() { { "raw", [rawMessage] } }
                    });
                default:
                    response.EnsureSuccessStatusCode();
                    return;
            }
        }
    }
}
