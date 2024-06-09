using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webislamdash.Models
{
    public class PrayerTime
    {
        public DateTime Date { get; set; }
        public string Fajr { get; set; }
        public string Sunrise { get; set; }
        public string Dhuhr { get; set; }
        public string Asr { get; set; }
        public string Sunset { get; set; }
        public string Maghrib { get; set; }
        public string Isha { get; set; }
    }
    public class GregorianCalendar
    {
        public string date { get; set; }
    }

    public class Date
    {
        public GregorianCalendar gregorian { get; set; }
    }

    public class DayPrayerTime
    {
        public PrayerTime Timings { get; set; }
        public Date date { get; set; }
    }

    public class PrayerTimeResponse
    {
        public int code { get; set; }
        public string status { get; set; }
        public List<DayPrayerTime> data { get; set; }
    }
}