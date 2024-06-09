using Newtonsoft.Json;
using System.Globalization;
using webislamdash.Models;

namespace webislamdash.Services
{
    public class PrayerTimeService : IPrayerTimeService
    {
        private readonly HttpClient _client;

        public PrayerTimeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<PrayerTime>> GetPrayerTimes(string city, string country)
        {
            var response = await _client.GetAsync($"http://api.aladhan.com/v1/calendarByCity?city={city}&country={country}&method=2");
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            var rawPrayerTimes = JsonConvert.DeserializeObject<PrayerTimeResponse>(stringResult);
            var prayerTimes = rawPrayerTimes.data?.Select(d =>
            {
                var prayerTime = d.Timings;
                prayerTime.Date = DateTime.ParseExact(d.date.gregorian.date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                return prayerTime;
            }).ToList() ?? new List<PrayerTime>();

            return prayerTimes;
        }

    }
}
