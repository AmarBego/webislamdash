using webislamdash.Models;

namespace webislamdash.Services
{
    public interface IPrayerTimeService
    {
        Task<List<PrayerTime>> GetPrayerTimes(string city, string country);
    }
}
