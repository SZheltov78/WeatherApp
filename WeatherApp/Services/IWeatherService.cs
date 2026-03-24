using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<CurrentWeatherApiResponse> GetCurrentWeatherAsync();
        Task<ForecastWeatherApiResponse> GetForecastWeatherAsync();
    }
}