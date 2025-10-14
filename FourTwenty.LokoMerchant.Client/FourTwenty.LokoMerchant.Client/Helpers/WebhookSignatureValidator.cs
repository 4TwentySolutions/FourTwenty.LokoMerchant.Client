using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;

namespace FourTwenty.LokoMerchant.Client.Helpers;

/// <summary>
/// Provides webhook signature validation using HMAC-SHA512.
/// </summary>
public static class WebhookSignatureValidator
{
    /// <summary>
    /// Verifies the HMAC-SHA512 signature of a webhook envelope to ensure authenticity and integrity.
    /// </summary>
    /// <param name="webhookEnvelope">The webhook envelope JSON element containing 'data' and 'signature' properties.</param>
    /// <param name="secretKey">The secret key used to compute the HMAC signature.</param>
    /// <returns>True if the signature is valid and matches the computed signature; otherwise, false.</returns>
    /// <remarks>
    /// <para>This method performs the following validations:</para>
    /// <list type="number">
    /// <item><description>Verifies the webhook envelope contains both 'data' and 'signature' properties</description></item>
    /// <item><description>Validates the signature is a non-empty string</description></item>
    /// <item><description>Checks the signature length is exactly 128 characters (SHA-512 hex output)</description></item>
    /// <item><description>Computes the expected signature from the data and compares using constant-time comparison to prevent timing attacks</description></item>
    /// </list>
    /// <para>The signature comparison is case-insensitive and uses constant-time equality to prevent timing attacks.</para>
    /// </remarks>
    public static bool VerifyWebhook(JsonElement webhookEnvelope, string secretKey)
    {
        if (!webhookEnvelope.TryGetProperty("data", out var dataElement))
            return false;


        if (!webhookEnvelope.TryGetProperty("signature", out var signatureElement))
            return false;


        var signature = signatureElement.GetString();
        if (string.IsNullOrEmpty(signature))
            return false;


        // Normalize incoming signature (trim + lowercase)
        signature = signature.Trim().ToLowerInvariant();

        // quick sanity check: sha512 hex is 128 chars
        if (signature.Length != 128)
            return false;

        var computed = GenerateSignature(dataElement, secretKey);

        // Constant time compare
        return CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(computed), Encoding.UTF8.GetBytes(signature));
    }

    /// <summary>
    /// Verifies the HMAC-SHA512 signature of a webhook by parsing the JSON string and validating its signature.
    /// </summary>
    /// <param name="webhookJson">The webhook JSON string containing 'data' and 'signature' properties.</param>
    /// <param name="secretKey">The secret key used to compute the HMAC signature.</param>
    /// <returns>True if the signature is valid and matches the computed signature; otherwise, false.</returns>
    /// <remarks>
    /// This is a convenience overload that deserializes the JSON string before validating the signature.
    /// See <see cref="VerifyWebhook(JsonElement, string)"/> for detailed validation logic.
    /// </remarks>
    public static bool VerifyWebhook(string webhookJson, string secretKey)
    {
        return VerifyWebhook(JsonSerializer.Deserialize<JsonElement>(webhookJson), secretKey);
    }

    /// <summary>
    /// Generates an HMAC-SHA512 signature for the given JSON data using the secret key.
    /// </summary>
    /// <param name="data">The JSON element containing the data to sign.</param>
    /// <param name="secretKey">The secret key used to compute the HMAC signature.</param>
    /// <returns>The computed HMAC-SHA512 signature as a lowercase hexadecimal string (128 characters).</returns>
    /// <remarks>
    /// This method serializes the data with deterministic ordering (object properties sorted alphabetically)
    /// to ensure consistent signature generation across different platforms. This matches the PHP backend
    /// implementation that uses json_encode with sorted keys.
    /// </remarks>
    public static string GenerateSignature(JsonElement data, string secretKey)
    {
        // Serialize data with deterministic ordering (object keys sorted recursively)
        var canonicalJson = SerializeWithSortedProperties(data);
        return ComputeHmacSha512(canonicalJson, secretKey);
    }

    /// <summary>
    /// Serializes a JSON element with all object properties sorted alphabetically to ensure deterministic output.
    /// </summary>
    /// <param name="element">The JSON element to serialize.</param>
    /// <returns>The serialized JSON string with properties sorted recursively.</returns>
    /// <remarks>
    /// This method ensures that JSON serialization produces identical output regardless of the original property order.
    /// It uses UnsafeRelaxedJsonEscaping to match PHP's json_encode behavior with JSON_UNESCAPED_UNICODE flag,
    /// which is necessary for signature verification compatibility with the backend.
    /// </remarks>
    private static string SerializeWithSortedProperties(JsonElement element)
    {
        // Create writer options that match PHP json_encode(flags: JSON_UNESCAPED_UNICODE) and no indentation
        var writerOptions = new JsonWriterOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Indented = false
        };

        using var ms = new System.IO.MemoryStream();
        using (var writer = new Utf8JsonWriter(ms, writerOptions))
        {
            WriteElementSorted(element, writer);
            writer.Flush();
        }

        return Encoding.UTF8.GetString(ms.ToArray());
    }

    /// <summary>
    /// Recursively writes a JSON element to the writer with object properties sorted alphabetically.
    /// </summary>
    /// <param name="element">The JSON element to write.</param>
    /// <param name="writer">The UTF-8 JSON writer to write to.</param>
    /// <remarks>
    /// <para>This method handles all JSON value types and ensures deterministic ordering:</para>
    /// <list type="bullet">
    /// <item><description>Objects: Properties are collected, sorted by name using ordinal comparison, and written recursively</description></item>
    /// <item><description>Arrays: Elements are written in their original order, with each element processed recursively</description></item>
    /// <item><description>Primitives: Strings, numbers, booleans, and null values are written directly</description></item>
    /// </list>
    /// <para>Number formatting is preserved using raw text to maintain exact representation, which is critical for signature verification.</para>
    /// </remarks>
    private static void WriteElementSorted(JsonElement element, Utf8JsonWriter writer)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                // collect properties, sort by name (ordinal) and write in that order
                var props = new List<JsonProperty>();
                foreach (var p in element.EnumerateObject())
                {
                    props.Add(p);
                }
                props.Sort((a, b) => StringComparer.Ordinal.Compare(a.Name, b.Name));

                writer.WriteStartObject();
                foreach (var prop in props)
                {
                    writer.WritePropertyName(prop.Name);
                    WriteElementSorted(prop.Value, writer);
                }
                writer.WriteEndObject();
                break;

            case JsonValueKind.Array:
                writer.WriteStartArray();
                foreach (var item in element.EnumerateArray())
                {
                    WriteElementSorted(item, writer);
                }
                writer.WriteEndArray();
                break;

            case JsonValueKind.String:
                writer.WriteStringValue(element.GetString());
                break;

            case JsonValueKind.Number:
                // Preserve raw number formatting from the incoming JSON
                writer.WriteRawValue(element.GetRawText());
                break;

            case JsonValueKind.True:
                writer.WriteBooleanValue(true);
                break;

            case JsonValueKind.False:
                writer.WriteBooleanValue(false);
                break;

            case JsonValueKind.Null:
            default:
                writer.WriteNullValue();
                break;
        }
    }

    /// <summary>
    /// Computes an HMAC-SHA512 hash of the data using the provided secret key.
    /// </summary>
    /// <param name="data">The data string to hash.</param>
    /// <param name="secretKey">The secret key used for HMAC computation.</param>
    /// <returns>The HMAC-SHA512 hash as a lowercase hexadecimal string (128 characters).</returns>
    /// <remarks>
    /// This method uses UTF-8 encoding for both the data and secret key, and returns the hash
    /// in lowercase hexadecimal format to match the expected signature format from the backend.
    /// </remarks>
    private static string ComputeHmacSha512(string data, string secretKey)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        using HMACSHA512 hmac = new HMACSHA512(keyBytes);
        return Convert.ToHexString(hmac.ComputeHash(dataBytes)).ToLowerInvariant();
    }
}
