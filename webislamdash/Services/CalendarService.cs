using Newtonsoft.Json;
using webislamdash.Models;
namespace webislamdash.Services
{
    public class CalendarService
    {
        private readonly HttpClient _httpClient;
        public CalendarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Day>> FetchHijriCalendar(int month, int year)
        {
            var response = await _httpClient.GetAsync($"http://api.aladhan.com/v1/gToHCalendar/{month}/{year}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                return apiResponse?.Data;
            }
            else
            {
                return null;
            }
        }
    }
}