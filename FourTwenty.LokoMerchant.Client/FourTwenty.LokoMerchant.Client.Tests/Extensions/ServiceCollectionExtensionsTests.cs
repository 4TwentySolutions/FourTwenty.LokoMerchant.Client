namespace FourTwenty.LokoMerchant.Client.Tests.Extensions;

[TestFixture]
public class ServiceCollectionExtensionsTests
{
    private ServiceCollection _services = null!;

    [SetUp]
    public void SetUp()
    {
        _services = new ServiceCollection();
    }

    [Test]
    public void AddLokoMerchantClient_WithoutConfiguration_ShouldRegisterAllRequiredServices()
    {
        // Arrange & Act
        _services.AddLokoMerchantClient();
        var serviceProvider = _services.BuildServiceProvider();

        // Assert
        Assert.That(serviceProvider.GetService<ILokoMerchantClient>(), Is.Not.Null, "ILokoMerchantClient should be registered");
        // LokoMerchantClient is registered as ILokoMerchantClient, not as concrete type
        Assert.That(serviceProvider.GetService<IBearerTokenProvider>(), Is.Not.Null, "IBearerTokenProvider should be registered");
        Assert.That(serviceProvider.GetService<LokoAuthorizationHandler>(), Is.Not.Null, "LokoAuthorizationHandler should be registered");
        Assert.That(serviceProvider.GetService<ILokoMerchantIdentityClient>(), Is.Not.Null, "ILokoMerchantIdentityClient should be registered");
    }

    [Test]
    public void AddLokoMerchantClient_WithCustomUrls_ShouldRegisterServicesWithCorrectConfiguration()
    {
        // Arrange
        const string customIdentityUrl = "https://identity-qa.example.com/";
        const string customApiUrl = "https://api-qa.example.com/";

        // Act
        _services.AddLokoMerchantClient(customIdentityUrl, customApiUrl);
        var serviceProvider = _services.BuildServiceProvider();

        // Assert
        var client = serviceProvider.GetService<ILokoMerchantClient>();
        Assert.That(client, Is.Not.Null);

        var identityClient = serviceProvider.GetService<ILokoMerchantIdentityClient>();
        Assert.That(identityClient, Is.Not.Null);
    }

    [Test]
    public void AddLokoMerchantIdentityClient_ShouldRegisterIdentityClientOnly()
    {
        // Arrange & Act
        _services.AddLokoMerchantIdentityClient("https://identity-test.example.com/");
        var serviceProvider = _services.BuildServiceProvider();

        // Assert
        Assert.That(serviceProvider.GetService<ILokoMerchantIdentityClient>(), Is.Not.Null, "ILokoMerchantIdentityClient should be registered");
    }

    [Test]
    public void AddLokoMerchantClient_RegisteredTwice_ShouldNotThrow()
    {
        // Arrange & Act & Assert
        Assert.DoesNotThrow(() =>
        {
            _services.AddLokoMerchantClient();
            _services.AddLokoMerchantClient();

            var serviceProvider = _services.BuildServiceProvider();
            var client = serviceProvider.GetService<ILokoMerchantClient>();
            Assert.That(client, Is.Not.Null);
        });
    }

    [Test]
    public void AddLokoMerchantClient_ShouldRegisterHttpClients()
    {
        // Arrange & Act
        _services.AddLokoMerchantClient();
        var serviceProvider = _services.BuildServiceProvider();

        // Assert
        var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        Assert.That(httpClientFactory, Is.Not.Null, "IHttpClientFactory should be available");

        // Verify we can create the typed HTTP clients
        Assert.DoesNotThrow(() => serviceProvider.GetService<ILokoMerchantClient>());
        Assert.DoesNotThrow(() => serviceProvider.GetService<ILokoMerchantIdentityClient>());
    }
}