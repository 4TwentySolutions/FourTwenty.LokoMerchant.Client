namespace FourTwenty.LokoMerchant.Client.Models
{
    public record WorkSchedule
    {

        [JsonPropertyName("dailyWorkingHours"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<BranchDaySchedule>? DailyWorkingSchedule { get; init; }


        [JsonPropertyName("weeklyWorkingHours"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BaseSchedule? WeeklyWorkingHours { get; init; }

        [JsonPropertyName("start"), JsonConverter(typeof(DateJsonConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? Start { get; init; }

        [JsonPropertyName("end"), JsonConverter(typeof(DateJsonConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? End { get; init; }

    }
}
