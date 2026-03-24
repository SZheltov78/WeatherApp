using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using WeatherApp.Models;


namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherApiService, IDisposable
    {
        private const string ApiKey = "fa8b3df74d4042b9aa7135114252304";
        private const string MoscowLatLon = "55.7558,37.6173";  // Москва

        public WeatherApiService()
        {            
            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.Expect100Continue = false;
        }

        private async Task<string> DownloadStringWithDecompressionAsync(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
                        
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;            
            
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/png,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
            request.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/145.0.0.0 Safari/537.36";

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<CurrentWeatherApiResponse> GetCurrentWeatherAsync()
        {
            try
            {
                string url = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={MoscowLatLon}";
                string json = await DownloadStringWithDecompressionAsync(url);                

                return JsonConvert.DeserializeObject<CurrentWeatherApiResponse>(json);
            }
            catch (WebException webEx)
            {
                string responseText = string.Empty;
                if (webEx.Response != null)
                {
                    using (var stream = webEx.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        responseText = await reader.ReadToEndAsync();
                    }
                }
                throw new Exception($"Ошибка при получении текущей погоды: {webEx.Message}. Ответ: {responseText}", webEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении текущей погоды: {ex.Message}", ex);
            }
        }

        public async Task<ForecastWeatherApiResponse> GetForecastWeatherAsync()
        {
            try
            {                
                string url = $"http://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={MoscowLatLon}&days=3";
                string json = await DownloadStringWithDecompressionAsync(url);

                // Отладка
                System.Diagnostics.Debug.WriteLine("=== Forecast Weather Response ===");
                System.Diagnostics.Debug.WriteLine(json?.Substring(0, Math.Min(300, json?.Length ?? 0)));

                return JsonConvert.DeserializeObject<ForecastWeatherApiResponse>(json);
            }
            catch (WebException webEx)
            {
                string responseText = string.Empty;
                if (webEx.Response != null)
                {
                    using (var stream = webEx.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        responseText = await reader.ReadToEndAsync();
                    }
                }
                throw new Exception($"Ошибка при получении прогноза погоды: {webEx.Message}. Ответ: {responseText}", webEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении прогноза погоды: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            //
        }
    }
}