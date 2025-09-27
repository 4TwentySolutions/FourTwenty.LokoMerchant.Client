using Microsoft.Extensions.Options;

namespace FourTwenty.LokoMerchant.Client.Authorization
{
    public class BearerTokenProvider : IBearerTokenProvider
    {
        private readonly ILokoMerchantIdentityClient _identityClient;
        private readonly LokoMerchantConfig _config;
        private string? _token;
        private DateTime _expiresAt;

        public BearerTokenProvider(ILokoMerchantIdentityClient identityClient, IOptions<LokoMerchantConfig> config)
        {
            _identityClient = identityClient;
            _config = config.Value;
        }

        public async Task<string> GetToken(CancellationToken ct = default)
        {
            if (_token != null && DateTime.UtcNow < _expiresAt) return _token;

            LokoAuthResponse? response = await _identityClient.GetToken(_config.ClientId, _config.ClientSecret, ct);
            _token = response?.AccessToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(response?.Expires ?? 0);
            return _token ?? throw new LokoException(new LokoErrorResponse() { Message = "Failed to retrieve access token" });
        }
    }
}
