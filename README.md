# FourTwenty.LokoMerchant.Client

.NET client library for the Loko Merchant API, simplifying delivery order management, pricing queries, and webhook integration in C#.

## Features

- **Store Management**: Update store status (pause/unpause) and manage schedules
- **Webhook Management**: Create, update, delete webhook subscriptions and retrieve events
- **Menu Management**: Import products, offers, categories, and complete menu structures
- **OAuth 2.0 Authentication**: Secure client credentials authentication
- **Async/Await Support**: Modern C# async patterns throughout
- **Strongly Typed**: Complete type safety with comprehensive models
- **Dependency Injection**: Easy integration with .NET Core DI container

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package FourTwenty.LokoMerchant.Client
```

Or via Package Manager Console in Visual Studio:

```
Install-Package FourTwenty.LokoMerchant.Client
```

## Quick Start

### Basic Usage

```csharp
using FourTwenty.LokoMerchant.Client;
using FourTwenty.LokoMerchant.Client.Models;

// Configure HttpClient with base URL and authentication
var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://merchant-api.silpo.ua/");

// Add bearer token to requests (see Authentication section below)
httpClient.DefaultRequestHeaders.Authorization = 
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "your-access-token");

// Create the client
var client = new LokoMerchantClient(httpClient);

// Use the client
await client.Store.UpdateStatus("store-id", StoreStatus.Unpause, new BranchStatusBodyRequest());
var subscriptions = await client.Webhooks.GetSubscriptions();
var importResult = await client.Menu.ImportProducts(new ImportProductRequest());
```

### Authentication

The Loko Merchant API uses OAuth 2.0 client credentials flow. Here's how to set up authentication:

```csharp
using FourTwenty.LokoMerchant.Client;
using FourTwenty.LokoMerchant.Client.Identity;

// Create identity client for authentication
var identityHttpClient = new HttpClient { BaseAddress = new Uri("https://auth.silpo.ua/") };
var identityClient = new LokoMerchantIdentityClient(identityHttpClient);

// Get access token
var config = new LokoMerchantConfig
{
    ClientId = "your-client-id",
    ClientSecret = "your-client-secret"
};

var tokenResponse = await identityClient.GetToken(config.ClientId, config.ClientSecret);
if (tokenResponse != null)
{
    // Configure API client with the access token
    var apiHttpClient = new HttpClient { BaseAddress = new Uri("https://merchant-api.silpo.ua/") };
    apiHttpClient.DefaultRequestHeaders.Authorization = 
        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
    
    var client = new LokoMerchantClient(apiHttpClient);
    // Use the client...
}
```

## ASP.NET Core Integration

### Using Extension Methods (Recommended)

The easiest way to integrate with ASP.NET Core is using the provided extension methods:

```csharp
using FourTwenty.LokoMerchant.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure Loko Merchant client with extension method
builder.Services.AddLokoMerchantClient(options =>
{
    options.ClientId = builder.Configuration["LokoMerchant:ClientId"];
    options.ClientSecret = builder.Configuration["LokoMerchant:ClientSecret"];
    // Optional: Configure custom URLs (defaults to production)
    options.IdentityBaseUrl = builder.Configuration["LokoMerchant:IdentityBaseUrl"]; 
    options.ApiBaseUrl = builder.Configuration["LokoMerchant:ApiBaseUrl"];
});

var app = builder.Build();
```

### Using Method Parameters for URLs (Alternative)

You can also pass URLs directly as method parameters for staging/testing environments:

```csharp
builder.Services.AddLokoMerchantClient(
    identityBaseUrl: "https://staging-identity.loko-merchant.com/",
    apiBaseUrl: "https://staging-api.loko-merchant.com/",
    options =>
    {
        options.ClientId = builder.Configuration["LokoMerchant:ClientId"];
        options.ClientSecret = builder.Configuration["LokoMerchant:ClientSecret"];
    });
```

**Note:** Using configuration properties is the preferred approach as it's more flexible and testable.

### Manual HttpClient Factory Setup

If you need more control over the configuration:

```csharp
using FourTwenty.LokoMerchant.Client;
using FourTwenty.LokoMerchant.Client.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configure Loko Merchant settings
builder.Services.Configure<LokoMerchantConfig>(
    builder.Configuration.GetSection("LokoMerchant"));

// Register HttpClient for identity server
builder.Services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>(client =>
{
    client.BaseAddress = new Uri("https://auth.silpo.ua/");
});

// Register HttpClient for API with token authentication
builder.Services.AddHttpClient<ILokoMerchantClient, LokoMerchantClient>(async (serviceProvider, client) =>
{
    client.BaseAddress = new Uri("https://merchant-api.silpo.ua/");
    
    // Get token and set authorization header
    var config = serviceProvider.GetRequiredService<IOptions<LokoMerchantConfig>>().Value;
    var identityClient = serviceProvider.GetRequiredService<ILokoMerchantIdentityClient>();
    
    var tokenResponse = await identityClient.GetToken(config.ClientId, config.ClientSecret);
    if (tokenResponse != null)
    {
        client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
    }
});

var app = builder.Build();
```

var app = builder.Build();
```

```csharp
using FourTwenty.LokoMerchant.Client;
using FourTwenty.LokoMerchant.Client.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configure Loko Merchant settings
builder.Services.Configure<LokoMerchantConfig>(
    builder.Configuration.GetSection("LokoMerchant"));

// Register HttpClient for identity server
builder.Services.AddHttpClient<ILokoMerchantIdentityClient, LokoMerchantIdentityClient>(client =>
{
    client.BaseAddress = new Uri("https://auth.silpo.ua/");
});

// Register HttpClient for API with token authentication
builder.Services.AddHttpClient<ILokoMerchantClient, LokoMerchantClient>(async (serviceProvider, client) =>
{
    client.BaseAddress = new Uri("https://merchant-api.silpo.ua/");
    
    // Get token and set authorization header
    var config = serviceProvider.GetRequiredService<IOptions<LokoMerchantConfig>>().Value;
    var identityClient = serviceProvider.GetRequiredService<ILokoMerchantIdentityClient>();
    
    var tokenResponse = await identityClient.GetToken(config.ClientId, config.ClientSecret);
    if (tokenResponse != null)
    {
        client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
    }
});

var app = builder.Build();
```

### Configuration (appsettings.json)

```json
{
  "LokoMerchant": {
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret",
    "IdentityBaseUrl": "https://auth.silpo.ua/",
    "ApiBaseUrl": "https://merchant-api.silpo.ua/"
  }
}
```

The `IdentityBaseUrl` and `ApiBaseUrl` properties are optional and will default to production URLs if not specified.

### Using in Controllers

```csharp
[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly ILokoMerchantClient _lokoClient;

    public StoreController(ILokoMerchantClient lokoClient)
    {
        _lokoClient = lokoClient;
    }

    [HttpPost("{storeId}/pause")]
    public async Task<IActionResult> PauseStore(string storeId)
    {
        try
        {
            await _lokoClient.Store.UpdateStatus(storeId, StoreStatus.Pause, new BranchStatusBodyRequest());
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("menu/products")]
    public async Task<IActionResult> ImportProducts(ImportProductRequest request)
    {
        try
        {
            var result = await _lokoClient.Menu.ImportProducts(request);
            return Ok(new { ImportId = result?.Id });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

## Usage Examples

### Store Management

```csharp
// Pause a store
await client.Store.UpdateStatus("store-123", StoreStatus.Pause, new BranchStatusBodyRequest());

// Unpause a store
await client.Store.UpdateStatus("store-123", StoreStatus.Unpause, new BranchStatusBodyRequest());

// Update store schedule
var schedules = new List<BranchDaySchedule>
{
    new BranchDaySchedule
    {
        // Configure schedule details
    }
};
await client.Store.UpdateSchedule("store-123", schedules);

// Update multiple stores' schedules
var storeSchedules = new List<BranchDayStoreSchedule>
{
    new BranchDayStoreSchedule
    {
        // Configure store schedule details
    }
};
await client.Store.UpdateStoresSchedule(storeSchedules);
```

### Webhook Management

```csharp
// Create a webhook subscription
var subscriptionRequest = new SubscriptionRequest
{
    Callback = "https://your-app.com/webhooks/loko",
    Events = new List<WebhookEvent> { WebhookEvent.OrderCreated, WebhookEvent.OrderStatusChanged },
    CompanyIds = new List<string> { "company-123" }
};

var subscription = await client.Webhooks.CreateSubscription(subscriptionRequest);
Console.WriteLine($"Subscription created with ID: {subscription?.Id}");
Console.WriteLine($"Webhook secret: {subscription?.Secret}");

// List all subscriptions
var subscriptions = await client.Webhooks.GetSubscriptions();
foreach (var sub in subscriptions?.Items ?? Enumerable.Empty<SubscriptionResponse>())
{
    Console.WriteLine($"Subscription: {sub.Id} -> {sub.Callback}");
}

// Update a subscription
var updateRequest = new SubscriptionRequest
{
    Callback = "https://your-app.com/webhooks/loko-updated",
    Events = new List<WebhookEvent> { WebhookEvent.OrderCreated }
};
await client.Webhooks.UpdateSubscription("subscription-id", updateRequest);

// Delete a subscription
await client.Webhooks.DeleteSubscription("subscription-id");

// Get webhook events history
var events = await client.Webhooks.GetSubscriptionEvents();
```

### Menu Management

```csharp
// Import products
var productRequest = new ImportProductRequest
{
    // Configure products to import
};
var importResult = await client.Menu.ImportProducts(productRequest);
Console.WriteLine($"Import started with ID: {importResult?.Id}");

// Import offers (pricing)
var offersRequest = new ImportOffersRequest
{
    // Configure offers to import
};
await client.Menu.ImportOffers(offersRequest);

// Import categories
var categories = new List<Category>
{
    new Category
    {
        ExternalId = "cat-1",
        Name = "Main Dishes",
        Position = 1
    },
    new Category
    {
        ExternalId = "cat-2",
        Name = "Beverages",
        Position = 2,
        ParentExternalId = null
    }
};
await client.Menu.ImportCategories("company-123", categories);

// Import complete menu
var menuRequest = new ImportMenuRequest
{
    // Configure complete menu structure
};
await client.Menu.ImportMenu("company-123", menuRequest);

// Partial menu import (updates only specific items)
var partialRequest = new PartialImportRequest
{
    // Configure partial update
};
await client.Menu.PartialMenuImport(partialRequest);
```

## Error Handling

The client includes built-in error handling. API errors are automatically processed and thrown as exceptions:

```csharp
try
{
    await client.Store.UpdateStatus("invalid-store-id", StoreStatus.Pause, new BranchStatusBodyRequest());
}
catch (HttpRequestException ex)
{
    // Handle HTTP-related errors (network issues, API errors)
    Console.WriteLine($"Request failed: {ex.Message}");
}
catch (JsonException ex)
{
    // Handle JSON deserialization errors
    Console.WriteLine($"Invalid response format: {ex.Message}");
}
catch (Exception ex)
{
    // Handle other exceptions
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

## API Reference

### Core Interfaces

- **`ILokoMerchantClient`**: Main client interface providing access to all functionality
- **`IStoreProvider`**: Store management operations (status, scheduling)
- **`IWebhooksProvider`**: Webhook subscription management
- **`IMenuProvider`**: Menu and product catalog management
- **`IBearerTokenProvider`**: Token management for authentication

### Models

The library includes comprehensive models for all API entities:

- **Products**: `BaseProduct`, `Product`, `MenuProduct`
- **Categories**: `Category`, `MenuProductCategory`
- **Offers**: `BaseOffer`, `Offer`, `MenuOffer`
- **Options**: `Option`, `OptionGroup`, `OptionInner`
- **Schedules**: `BranchDaySchedule`, `WorkSchedule`
- **Webhooks**: `SubscriptionRequest`, `SubscriptionResponse`, `WebhookEvent`
- **Responses**: `IdResponse`, `PagedResponse<T>`, `LokoAuthResponse`

## API Documentation

For detailed API documentation, visit: [Loko Merchant API Documentation](https://loko-merchant-api.gitbook.io/merchant-docs/api-reference)

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For issues and questions:
- Create an issue on [GitHub](https://github.com/4TwentySolutions/FourTwenty.LokoMerchant.Client/issues)
- Check the [API documentation](https://loko-merchant-api.gitbook.io/merchant-docs/api-reference)
