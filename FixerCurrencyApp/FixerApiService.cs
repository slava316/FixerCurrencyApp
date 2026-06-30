using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace FixerCurrencyApp
{
    public class FixerApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "http://data.fixer.io/api/";

        public FixerApiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<FixerResponse> GetLatestRatesAsync()
        {
            string url = $"{BaseUrl}latest?access_key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<FixerResponse>(json);
        }

        public async Task<FixerResponse> GetHistoricalRatesAsync(string date)
        {
            // Формат даты строго YYYY-MM-DD
            string url = $"{BaseUrl}{date}?access_key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<FixerResponse>(json);
        }
    }
}