namespace FourTwenty.LokoMerchant.Client.Tests;

[TestFixture]
public class LokoMerchantConfigTests
{
    [Test]
    public void LokoMerchantConfig_WithRequiredProperties_ShouldHaveCorrectDefaults()
    {
        // Arrange & Act
        var config = new LokoMerchantConfig
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret"
        };

        // Assert
        Assert.That(config.ClientId, Is.EqualTo("test-client-id"));
        Assert.That(config.ClientSecret, Is.EqualTo("test-client-secret"));
        Assert.That(config.IdentityBaseUrl, Is.EqualTo("https://auth.silpo.ua/"));
        Assert.That(config.ApiBaseUrl, Is.EqualTo("https://merchant-api.silpo.ua/"));
    }

    [Test]
    public void LokoMerchantConfig_WithCustomUrls_ShouldUseProvidedValues()
    {
        // Arrange
        const string customIdentityUrl = "https://identity-qa.example.com/";
        const string customApiUrl = "https://api-qa.example.com/";

        // Act
        var config = new LokoMerchantConfig
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret",
            IdentityBaseUrl = customIdentityUrl,
            ApiBaseUrl = customApiUrl
        };

        // Assert
        Assert.That(config.IdentityBaseUrl, Is.EqualTo(customIdentityUrl));
        Assert.That(config.ApiBaseUrl, Is.EqualTo(customApiUrl));
    }

    [TestCase("https://identity-public-qa.foodtech.team/", "QA Environment")]
    [TestCase("https://auth.silpo.ua/", "Production Environment")]
    [TestCase("https://localhost:5001/", "Local Development")]
    public void LokoMerchantConfig_WithDifferentEnvironmentUrls_ShouldAcceptValidUrls(string identityUrl, string description)
    {
        // Arrange & Act
        var config = new LokoMerchantConfig
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret",
            IdentityBaseUrl = identityUrl
        };

        // Assert
        Assert.That(config.IdentityBaseUrl, Is.EqualTo(identityUrl), $"Failed for {description}");
        Assert.That(Uri.IsWellFormedUriString(config.IdentityBaseUrl, UriKind.Absolute), Is.True, $"Invalid URL format for {description}");
    }

    [Test]
    public void LokoMerchantConfig_DefaultUrls_ShouldBeValidUris()
    {
        // Arrange & Act
        var config = new LokoMerchantConfig
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret"
        };

        // Assert
        Assert.That(Uri.IsWellFormedUriString(config.IdentityBaseUrl, UriKind.Absolute), Is.True, "IdentityBaseUrl should be a valid URI");
        Assert.That(Uri.IsWellFormedUriString(config.ApiBaseUrl, UriKind.Absolute), Is.True, "ApiBaseUrl should be a valid URI");
    }
}