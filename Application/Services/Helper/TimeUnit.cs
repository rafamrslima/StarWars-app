namespace StarWars.App.Services.Helper
{
    public class TimeUnit
    {
        public static readonly string _day = "day";
        public static readonly string _week = "week";
        public static readonly string _month = "month";
        public static readonly string _year = "year";

        public static bool IsDay(string duration) => duration.Contains(_day);
        public static bool IsWeek(string duration) => duration.Contains(_week);
        public static bool IsMonth(string duration) => duration.Contains(_month);
        public static bool IsYear(string duration) => duration.Contains(_year);
    }
}
