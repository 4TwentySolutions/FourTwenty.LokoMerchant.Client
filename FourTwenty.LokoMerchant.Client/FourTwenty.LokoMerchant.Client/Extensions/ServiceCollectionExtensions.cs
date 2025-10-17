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
    /// URLs can be configured via LokoMerchantConfig properties or will default to production endpoints.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configureOptions">An optional action to configure the LokoMerchantConfig.</param>
    /// <param name="configureApiClient">An optional action to configure the API client.</param>
    /// <param name="configureIdentityClient">An optional action to configure the identity client.</param>
    /// <returns>The IServiceCollection for method chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddLokoMerchantClient(options =>
    /// {
    ///     options.ClientId = "your-client-id";
    ///     options.ClientSecret = "your-client-secret";
    ///     options.IdentityBaseUrl = "https://identity-public-qa.foodtech.team/"; // Optional
    ///     options.ApiBaseUrl = "https://global-api-qa.foodtech.team/public/merchant"; // Optional
    /// });
    /// </code>
    /// </example>
    public static IServiceCollection AddLokoMerchantClient(
        this IServiceCollection services,
        Action<LokoMerchantConfig>? configureOptions = null,
        Action<IHttpClientBuilder>? configureApiClient = null,
        Action<IHttpClientBuilder>? configureIdentityClient = null)
    {
        // Configure options if provided
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        // Register token provider and authorization handler
        services.AddScoped<IBearerTokenProvider, BearerTokenProvider>();
        services.AddTransient<LokoAuthorizationHandler>();

        // Register HttpClient for identity server
        var identityClientBuilder = services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>((serviceProvider, client) =>
        {
            var config = serviceProvider.GetService<IOptions<LokoMerchantConfig>>()?.Value;
            client.BaseAddress = new Uri(config?.IdentityBaseUrl ?? "https://auth.silpo.ua/");
        });

        configureIdentityClient?.Invoke(identityClientBuilder);

        // Register HttpClient for API with authorization handler
        var apiClientBuilder = services.AddHttpClient<ILokoMerchantClient, LokoMerchantClient>((serviceProvider, client) =>
        {
            var config = serviceProvider.GetService<IOptions<LokoMerchantConfig>>()?.Value;
            client.BaseAddress = new Uri(config?.ApiBaseUrl ?? "https://merchant-api.silpo.ua/");
        })
        .AddHttpMessageHandler<LokoAuthorizationHandler>();

        configureApiClient?.Invoke(apiClientBuilder);

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
    /// <param name="configureApiClient">An optional action to configure the API client.</param>
    /// <param name="configureIdentityClient">An optional action to configure the identity client.</param>
    /// <returns>The IServiceCollection for method chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddLokoMerchantClient(
    ///     "https://identity-public-qa.foodtech.team/",
    ///     "https://global-api-qa.foodtech.team/public/merchant",
    ///     options =>
    ///     {
    ///         options.ClientId = "qa-client-id";
    ///         options.ClientSecret = "qa-client-secret";
    ///     });
    /// </code>
    /// </example>
    public static IServiceCollection AddLokoMerchantClient(
        this IServiceCollection services,
        string identityBaseUrl,
        string apiBaseUrl,
        Action<LokoMerchantConfig>? configureOptions = null,
        Action<IHttpClientBuilder>? configureApiClient = null,
        Action<IHttpClientBuilder>? configureIdentityClient = null)
    {
        // Configure options if provided
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        // Register token provider and authorization handler
        services.AddScoped<IBearerTokenProvider, BearerTokenProvider>();
        services.AddTransient<LokoAuthorizationHandler>();

        // Register HttpClient for identity server with custom URL
        var identityClientBuilder = services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>(client =>
        {
            client.BaseAddress = new Uri(identityBaseUrl);
        });
        configureIdentityClient?.Invoke(identityClientBuilder);

        // Register HttpClient for API with custom URL and authorization handler
        var apiClientBuilder = services.AddHttpClient<ILokoMerchantClient, LokoMerchantClient>(client =>
        {
            client.BaseAddress = new Uri(apiBaseUrl);
        })
        .AddHttpMessageHandler<LokoAuthorizationHandler>();

        configureApiClient?.Invoke(apiClientBuilder);

        return services;
    }

    /// <summary>
    /// Adds only the Loko Merchant identity client for authentication purposes.
    /// Use this when you need only token management functionality.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="identityBaseUrl">The base URL for the identity server. If not specified, uses the configured IdentityBaseUrl or defaults to production URL.</param>
    /// <param name="configureIdentityClient">An optional action to configure the identity client.</param>
    /// <returns>The IServiceCollection for method chaining.</returns>
    public static IServiceCollection AddLokoMerchantIdentityClient(
        this IServiceCollection services,
        string? identityBaseUrl = null,
        Action<IHttpClientBuilder>? configureIdentityClient = null)
    {
        var identityClientBuilder = services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>((serviceProvider, client) =>
        {
            if (identityBaseUrl != null)
            {
                client.BaseAddress = new Uri(identityBaseUrl);
            }
            else
            {
                var config = serviceProvider.GetService<IOptions<LokoMerchantConfig>>()?.Value;
                client.BaseAddress = new Uri(config?.IdentityBaseUrl ?? "https://auth.silpo.ua/");
            }
        });

        configureIdentityClient?.Invoke(identityClientBuilder);

        return services;
    }
}