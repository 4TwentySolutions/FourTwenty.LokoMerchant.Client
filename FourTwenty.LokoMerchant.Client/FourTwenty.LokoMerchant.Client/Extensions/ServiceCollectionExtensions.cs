using FourTwenty.LokoMerchant.Client.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FourTwenty.LokoMerchant.Client.Extensions;

/// <summary>
/// Extension methods for registering Loko Merchant client services with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Loko Merchant client services to the specified IServiceCollection.
    /// This method registers both the identity client for authentication and the main API client.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configureOptions">An optional action to configure the LokoMerchantConfig.</param>
    /// <returns>The IServiceCollection for method chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddLokoMerchantClient(options =>
    /// {
    ///     options.ClientId = "your-client-id";
    ///     options.ClientSecret = "your-client-secret";
    /// });
    /// </code>
    /// </example>
    public static IServiceCollection AddLokoMerchantClient(
        this IServiceCollection services,
        Action<LokoMerchantConfig>? configureOptions = null)
    {
        // Configure options if provided
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        // Register HttpClient for identity server
        services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>(client =>
        {
            client.BaseAddress = new Uri("https://identity.loko-merchant.com/");
        });

        // Register HttpClient for API with token authentication
        services.AddHttpClient<ILokoMerchantClient, LokoMerchantClient>(async (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://api.loko-merchant.com/");
            
            // Get token and set authorization header
            var config = serviceProvider.GetService<IOptions<LokoMerchantConfig>>()?.Value;
            if (config != null)
            {
                var identityClient = serviceProvider.GetRequiredService<ILokoMerchantIdentityClient>();
                var tokenResponse = await identityClient.GetToken(config.ClientId, config.ClientSecret);
                
                if (tokenResponse != null)
                {
                    client.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
                }
            }
        });

        return services;
    }

    /// <summary>
    /// Adds the Loko Merchant client services with custom base URLs for identity and API endpoints.
    /// Use this method when working with different environments or custom deployments.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="identityBaseUrl">The base URL for the identity server.</param>
    /// <param name="apiBaseUrl">The base URL for the API server.</param>
    /// <param name="configureOptions">An optional action to configure the LokoMerchantConfig.</param>
    /// <returns>The IServiceCollection for method chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddLokoMerchantClient(
    ///     "https://staging-identity.loko-merchant.com/",
    ///     "https://staging-api.loko-merchant.com/",
    ///     options =>
    ///     {
    ///         options.ClientId = "staging-client-id";
    ///         options.ClientSecret = "staging-client-secret";
    ///     });
    /// </code>
    /// </example>
    public static IServiceCollection AddLokoMerchantClient(
        this IServiceCollection services,
        string identityBaseUrl,
        string apiBaseUrl,
        Action<LokoMerchantConfig>? configureOptions = null)
    {
        // Configure options if provided
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        // Register HttpClient for identity server with custom URL
        services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>(client =>
        {
            client.BaseAddress = new Uri(identityBaseUrl);
        });

        // Register HttpClient for API with custom URL and token authentication
        services.AddHttpClient<ILokoMerchantClient, LokoMerchantClient>(async (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(apiBaseUrl);
            
            // Get token and set authorization header
            var config = serviceProvider.GetService<IOptions<LokoMerchantConfig>>()?.Value;
            if (config != null)
            {
                var identityClient = serviceProvider.GetRequiredService<ILokoMerchantIdentityClient>();
                var tokenResponse = await identityClient.GetToken(config.ClientId, config.ClientSecret);
                
                if (tokenResponse != null)
                {
                    client.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
                }
            }
        });

        return services;
    }

    /// <summary>
    /// Adds only the Loko Merchant identity client for authentication purposes.
    /// Use this when you need only token management functionality.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="identityBaseUrl">The base URL for the identity server. Defaults to production URL if not specified.</param>
    /// <returns>The IServiceCollection for method chaining.</returns>
    public static IServiceCollection AddLokoMerchantIdentityClient(
        this IServiceCollection services,
        string? identityBaseUrl = null)
    {
        services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>(client =>
        {
            client.BaseAddress = new Uri(identityBaseUrl ?? "https://identity.loko-merchant.com/");
        });

        return services;
    }
}