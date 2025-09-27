namespace FourTwenty.LokoMerchant.Client.Models.Responses
{
    public record LokoErrorResponse
    {
        public string? Message { get; init; }
        public int? Code { get; init; }

        public string[]? Errors { get; init; }
    }
}
