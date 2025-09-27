
namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BranchDaySchedule
    {
        [JsonPropertyName("weekDay"), JsonConverter(typeof(JsonStringEnumConverter<DayOfWeek>))]
        public DayOfWeek WeekDay { get; init; }

        [JsonPropertyName("open"), JsonConverter(typeof(TimespanJsonConverter))]
        public TimeSpan Open { get; init; }

        [JsonPropertyName("closed"), JsonConverter(typeof(TimespanJsonConverter))]
        public TimeSpan Closed { get; init; }
    }
}
