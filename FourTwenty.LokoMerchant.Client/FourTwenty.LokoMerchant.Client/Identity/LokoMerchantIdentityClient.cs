namespace FourTwenty.LokoMerchant.Client.Identity
{
    public class LokoMerchantIdentityClient(HttpClient httpClient) : ILokoMerchantIdentityClient
    {
        public async Task<LokoAuthResponse?> GetToken(string clientId, string clientSecret, CancellationToken ct = default)
        {
            var encodedContent = new FormUrlEncodedContent([
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            ]);

            var response = await httpClient.PostAsync("connect/token", encodedContent, ct);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<LokoAuthResponse>(ct);

            await ErrorHandlingHelper.HandleError(response, ct);
            return null;
        }
    }
}
