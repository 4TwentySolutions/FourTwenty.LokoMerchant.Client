namespace FourTwenty.LokoMerchant.Client.Tests;

[TestFixture]
public class LokoMerchantClientTests
{
    private HttpClient _httpClient = null!;
    private LokoMerchantClient _client = null!;

    [SetUp]
    public void SetUp()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://test-api.example.com/")
        };
        _client = new LokoMerchantClient(_httpClient);
    }

    [TearDown]
    public void TearDown()
    {
        _httpClient?.Dispose();
    }

    [Test]
    public void LokoMerchantClient_Constructor_ShouldCreateInstance()
    {
        // Arrange & Act & Assert
        Assert.That(_client, Is.Not.Null);
        Assert.That(_client, Is.InstanceOf<ILokoMerchantClient>());
    }

    [Test]
    public void Store_Property_ShouldReturnStoreProvider()
    {
        // Arrange & Act
        var storeProvider = _client.Store;

        // Assert
        Assert.That(storeProvider, Is.Not.Null);
        Assert.That(storeProvider, Is.InstanceOf<IStoreProvider>());
    }

    [Test]
    public void Webhooks_Property_ShouldReturnWebhooksProvider()
    {
        // Arrange & Act
        var webhooksProvider = _client.Webhooks;

        // Assert
        Assert.That(webhooksProvider, Is.Not.Null);
        Assert.That(webhooksProvider, Is.InstanceOf<IWebhooksProvider>());
    }

    [Test]
    public void Menu_Property_ShouldReturnMenuProvider()
    {
        // Arrange & Act
        var menuProvider = _client.Menu;

        // Assert
        Assert.That(menuProvider, Is.Not.Null);
        Assert.That(menuProvider, Is.InstanceOf<IMenuProvider>());
    }

    [Test]
    public void Orders_Property_ShouldReturnOrdersProvider()
    {
        // Arrange & Act
        var ordersProvider = _client.Orders;

        // Assert
        Assert.That(ordersProvider, Is.Not.Null);
        Assert.That(ordersProvider, Is.InstanceOf<IOrdersProvider>());
    }

    [Test]
    public void AllProviders_ShouldBeAccessible()
    {
        // Arrange & Act & Assert
        Assert.Multiple(() =>
        {
            Assert.That(_client.Store, Is.Not.Null, "Store provider should be accessible");
            Assert.That(_client.Webhooks, Is.Not.Null, "Webhooks provider should be accessible");
            Assert.That(_client.Menu, Is.Not.Null, "Menu provider should be accessible");
            Assert.That(_client.Orders, Is.Not.Null, "Orders provider should be accessible");
        });
    }

    [Test]
    public void Providers_ShouldReturnNewInstancesOnEachAccess()
    {
        // Arrange & Act
        var store1 = _client.Store;
        var store2 = _client.Store;
        var webhooks1 = _client.Webhooks;
        var webhooks2 = _client.Webhooks;

        // Assert
        Assert.That(store1, Is.Not.SameAs(store2), "Store provider should return new instances");
        Assert.That(webhooks1, Is.Not.SameAs(webhooks2), "Webhooks provider should return new instances");
    }

    [Test]
    public void Constructor_WithNullHttpClient_ShouldCreateInstanceWithNullProviders()
    {
        // Arrange & Act
        var client = new LokoMerchantClient(null!);

        // Assert - client is created but providers return instances that use null HttpClient
        Assert.That(client, Is.Not.Null);

        // Providers are created but will use null HttpClient internally
        var store = client.Store;
        Assert.That(store, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithValidHttpClient_ShouldNotThrow()
    {
        // Arrange
        using var httpClient = new HttpClient();

        // Act & Assert
        Assert.DoesNotThrow(() => new LokoMerchantClient(httpClient));
    }
}