using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherApiService
    {
        Task<CurrentWeatherApiResponse> GetCurrentWeatherAsync();
        Task<ForecastWeatherApiResponse> GetForecastWeatherAsync();
    }
}