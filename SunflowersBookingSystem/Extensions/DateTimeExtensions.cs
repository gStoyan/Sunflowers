namespace SunflowersBookingSystem.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime date, DateTime start, DateTime end) => date > start && date < end;
    }
}
