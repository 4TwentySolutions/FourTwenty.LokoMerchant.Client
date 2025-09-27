
namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BranchDaySchedule : BaseSchedule
    {
        [JsonPropertyName("weekDay"), JsonConverter(typeof(JsonStringEnumConverter<DayOfWeek>))]
        public DayOfWeek WeekDay { get; init; }
    }
}
