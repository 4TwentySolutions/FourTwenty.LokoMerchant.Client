namespace FourTwenty.LokoMerchant.Client.Converters
{
    public class LowerCaseEnumConverter() : JsonStringEnumConverter(new LowerCaseNamingPolicy());

    public class LowerCaseEnumConverter<T>() : JsonStringEnumConverter<T>(new LowerCaseNamingPolicy())
        where T : struct, Enum;
}
