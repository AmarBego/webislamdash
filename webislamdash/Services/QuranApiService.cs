using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using webislamdash.Models;

namespace webislamdash.Services
{
    public class QuranApiService
    {
        private readonly HttpClient _httpClient;

        public QuranApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<QuranPage?> FetchPage(int pageNumber)
        {
            var response = await _httpClient.GetAsync($"https://api.alquran.cloud/v1/page/{pageNumber}/en.asad");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<QuranApiResponse>(jsonString);
                return apiResponse?.Data;
            }
            else
            {
                return null;
            }
        }
    }
}