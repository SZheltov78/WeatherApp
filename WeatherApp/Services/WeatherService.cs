using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;
using WeatherApp.Models.Common;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "fa8b3df74d4042b9aa7135114252304";
        private const string BaseUrl = "http://api.weatherapi.com/v1/";
        private const string MoscowLocation = "Moscow";

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<CurrentWeatherApiResponse> GetCurrentWeatherAsync()
        {
            try
            {
                string url = $"current.json?key={ApiKey}&q={MoscowLocation}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CurrentWeatherApiResponse>(json);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                throw new Exception($"Ошибка при получении текущей погоды: {ex.Message}", ex);
            }
        }

        public async Task<ForecastWeatherApiResponse> GetForecastWeatherAsync()
        {
            try
            {
                string url = $"forecast.json?key={ApiKey}&q={MoscowLocation}&days=3";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ForecastWeatherApiResponse>(json);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                throw new Exception($"Ошибка при получении прогноза погоды: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}