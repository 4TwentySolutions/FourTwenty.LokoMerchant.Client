using FourTwenty.LokoMerchant.Client.Helpers;

namespace FourTwenty.LokoMerchant.Client.Tests.Helpers;

[TestFixture]
public class WebhookSignatureValidatorTests
{
    private const string TestSecretKey = "supersecret";

    [Test]
    public void GenerateSignature_WithSimpleData_ShouldReturnValidSignature()
    {
        // Arrange
        var dataJson = """{"orderId":"123"}""";
        var data = JsonSerializer.Deserialize<JsonElement>(dataJson);

        // Act
        var signature = WebhookSignatureValidator.GenerateSignature(data, TestSecretKey);

        // Assert
        Assert.That(signature, Is.Not.Null);
        Assert.That(signature, Is.Not.Empty);
        Assert.That(signature.Length, Is.EqualTo(128)); // SHA512 produces 128 hex characters
    }


    [Test]
    public void VerifyWebhook_WithValidSignature_ShouldReturnTrue()
    {
        // Arrange
        var data = JsonSerializer.Deserialize<JsonElement>("""{"orderId":"123"}""");
        var signature = WebhookSignatureValidator.GenerateSignature(data, TestSecretKey);
        var webhookJson = $$"""{"event":"order.new","data":{"orderId":"123"},"signature":"{{signature}}"}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.True, "Valid signature should be verified successfully");
    }

    [Test]
    public void VerifyWebhook_WithInvalidSignature_ShouldReturnFalse()
    {
        // Arrange
        var invalidSignature = "0".PadRight(128, '0');
        var webhookJson = $$"""{"event":"order.new","data":{"orderId":"123"},"signature":"{{invalidSignature}}"}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.False, "Invalid signature should fail verification");
    }

    [Test]
    public void VerifyWebhook_WithModifiedData_ShouldReturnFalse()
    {
        // Arrange
        var originalData = JsonSerializer.Deserialize<JsonElement>("""{"orderId":"123"}""");
        var signature = WebhookSignatureValidator.GenerateSignature(originalData, TestSecretKey);
        var modifiedWebhookJson = $$"""{"event":"order.new","data":{"orderId":"456"},"signature":"{{signature}}"}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(modifiedWebhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.False, "Modified data should fail signature verification");
    }

    [Test]
    public void VerifyWebhook_WithDifferentSecretKey_ShouldReturnFalse()
    {
        // Arrange
        var data = JsonSerializer.Deserialize<JsonElement>("""{"orderId":"123"}""");
        var signature = WebhookSignatureValidator.GenerateSignature(data, TestSecretKey);
        var webhookJson = $$"""{"event":"order.new","data":{"orderId":"123"},"signature":"{{signature}}"}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, "different-secret");

        // Assert
        Assert.That(isValid, Is.False, "Verification with different secret key should fail");
    }

    [Test]
    public void VerifyWebhook_WithMissingDataField_ShouldReturnFalse()
    {
        // Arrange
        var webhookJson = """{"event":"order.new","signature":"abc123"}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.False, "Missing data field should fail verification");
    }

    [Test]
    public void VerifyWebhook_WithMissingSignatureField_ShouldReturnFalse()
    {
        // Arrange
        var webhookJson = """{"event":"order.new","data":{"orderId":"123"}}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.False, "Missing signature field should fail verification");
    }

    [Test]
    public void GenerateSignature_WithArrays_ShouldProcessArrayElements()
    {
        // Arrange
        var data1 = JsonSerializer.Deserialize<JsonElement>("""{"items":[{"id":"1"},{"id":"2"}]}""");
        var data2 = JsonSerializer.Deserialize<JsonElement>("""{"items":[{"id":"1"},{"id":"2"}]}""");

        // Act
        var signature1 = WebhookSignatureValidator.GenerateSignature(data1, TestSecretKey);
        var signature2 = WebhookSignatureValidator.GenerateSignature(data2, TestSecretKey);

        // Assert
        Assert.That(signature1, Is.EqualTo(signature2), "Arrays should be handled correctly");
    }

    [Test]
    public void VerifyWebhook_WithComplexPayload_ShouldVerifyCorrectly()
    {
        // Arrange
        var dataJson = """
        {
            "id": "550e8400-e29b-41d4-a716-446655440000",
            "number": "ORD-001",
            "storeId": "store-123",
            "status": "new",
            "listPrice": {
                "value": 100.50,
                "currency": "UAH"
            },
            "items": [
                {
                    "id": "item-1",
                    "name": "Product 1",
                    "quantityOrdered": 2
                }
            ],
            "customer": {
                "firstName": "John",
                "lastName": "Doe",
                "phone": "+380501234567"
            }
        }
        """;
        var data = JsonSerializer.Deserialize<JsonElement>(dataJson);
        var signature = WebhookSignatureValidator.GenerateSignature(data, TestSecretKey);

        var webhookJson = $$"""
        {
            "event": "order.new",
            "signature": "{{signature}}",
            "data": {{dataJson}}
        }
        """;

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.True, "Complex webhook payload should verify correctly");
    }

    [Test]
    public void VerifyWebhook_SignatureOnlyCoversData_NotEventOrSignature()
    {
        // Arrange - Generate signature for just the data
        var data = JsonSerializer.Deserialize<JsonElement>("""{"orderId":"123"}""");
        var signature = WebhookSignatureValidator.GenerateSignature(data, TestSecretKey);

        // Create webhook with different event name - should still verify if data is unchanged
        var webhookJson = $$"""{"event":"order.status.changed","data":{"orderId":"123"},"signature":"{{signature}}"}""";

        // Act
        var isValid = WebhookSignatureValidator.VerifyWebhook(webhookJson, TestSecretKey);

        // Assert
        Assert.That(isValid, Is.True, "Signature should only validate data field, not event or signature fields");
    }
}
