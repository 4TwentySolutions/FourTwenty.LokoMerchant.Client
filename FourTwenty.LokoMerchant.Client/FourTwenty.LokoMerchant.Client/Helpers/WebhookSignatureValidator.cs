using System.Security.Cryptography;
using System.Text;

namespace FourTwenty.LokoMerchant.Client.Helpers;

/// <summary>
/// Provides webhook signature validation using HMAC-SHA512.
/// </summary>
public static class WebhookSignatureValidator
{
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
    {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = false
    };

    /// <summary>
    /// Verifies the signature of a webhook payload using timing-safe comparison.
    /// Extracts the 'data' field from the webhook envelope and validates its signature.
    /// </summary>
    /// <param name="webhookEnvelope">The complete webhook envelope containing event, data, and signature fields.</param>
    /// <param name="secretKey">The secret key used for signing.</param>
    /// <returns>True if the signature is valid; otherwise, false.</returns>
    public static bool VerifyWebhook(JsonElement webhookEnvelope, string secretKey)
    {
        if (!webhookEnvelope.TryGetProperty("data", out var data))
            return false;

        if (!webhookEnvelope.TryGetProperty("signature", out var signatureElement))
            return false;

        var signature = signatureElement.GetString();
        if (string.IsNullOrEmpty(signature))
            return false;

        var generatedSignature = GenerateSignature(data, secretKey);
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(generatedSignature),
            Encoding.UTF8.GetBytes(signature)
        );
    }

    /// <summary>
    /// Verifies the signature of a webhook payload from a JSON string.
    /// </summary>
    /// <param name="webhookJson">The complete webhook JSON string.</param>
    /// <param name="secretKey">The secret key used for signing.</param>
    /// <returns>True if the signature is valid; otherwise, false.</returns>
    public static bool VerifyWebhook(string webhookJson, string secretKey)
    {
        var envelope = JsonSerializer.Deserialize<JsonElement>(webhookJson);
        return VerifyWebhook(envelope, secretKey);
    }

    /// <summary>
    /// Generates an HMAC-SHA512 signature for the provided data payload.
    /// This method signs only the data portion, not the entire webhook envelope.
    /// </summary>
    /// <param name="data">The data to sign (typically the 'data' field from a webhook).</param>
    /// <param name="secretKey">The secret key used for signing.</param>
    /// <returns>The generated signature as a hexadecimal string.</returns>
    public static string GenerateSignature(JsonElement data, string secretKey)
    {
        var encodedData = JsonSerializer.Serialize(data, JsonOptions);

        return ComputeHmacSha512(encodedData, secretKey);
    }

    /// <summary>
    /// Computes the HMAC-SHA512 hash of the input data.
    /// </summary>
    /// <param name="data">The data to hash.</param>
    /// <param name="secretKey">The secret key for HMAC.</param>
    /// <returns>The hash as a hexadecimal string.</returns>
    private static string ComputeHmacSha512(string data, string secretKey)
    {
        var keyBytes = Encoding.UTF8.GetBytes(secretKey);
        var dataBytes = Encoding.UTF8.GetBytes(data);

        using var hmac = new HMACSHA512(keyBytes);
        var hashBytes = hmac.ComputeHash(dataBytes);

        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}
