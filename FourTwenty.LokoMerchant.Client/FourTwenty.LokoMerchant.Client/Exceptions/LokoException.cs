namespace FourTwenty.LokoMerchant.Client.Exceptions
{
    public class LokoException(LokoErrorResponse? errorResponse) : Exception(errorResponse?.Message)
    {
        public LokoErrorResponse ErrorResponse { get; } = errorResponse ?? new LokoErrorResponse { Message = "An unknown error occurred." };
    }
}
