
namespace FourTwenty.LokoMerchant.Client.Models
{
    public record BranchDaySchedule : BaseSchedule
    {
        [JsonPropertyName("weekDay"), JsonConverter(typeof(LowerCaseEnumConverter<DayOfWeek>))]
        public DayOfWeek WeekDay { get; init; }
    }
}
