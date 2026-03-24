using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Models.ViewModels;

namespace WeatherApp.Services
{
    public class WeatherViewModelService : IWeatherViewModelService
    {
        private readonly IWeatherApiService _weatherApiService;

        public WeatherViewModelService(IWeatherApiService weatherApiService)
        {
            _weatherApiService = weatherApiService;
        }

        public async Task<WeatherViewModel> GetWeatherViewModelAsync()
        {
            var currentResponse = await _weatherApiService.GetCurrentWeatherAsync();
            var forecastResponse = await _weatherApiService.GetForecastWeatherAsync();

            var result = MapToViewModel(currentResponse, forecastResponse);

            return result;
        }

        private WeatherViewModel MapToViewModel(
            CurrentWeatherApiResponse currentResponse,
            ForecastWeatherApiResponse forecastResponse)
        {
            var viewModel = new WeatherViewModel
            {
                Location = new LocationInfo
                {
                    Name = currentResponse.Location.Name,
                    Country = currentResponse.Location.Country,
                    LocalTime = currentResponse.Location.Localtime
                },

                CurrentWeather = new CurrentWeatherInfo
                {
                    TemperatureC = currentResponse.Current.TempC,
                    TemperatureF = currentResponse.Current.TempF,
                    FeelsLikeC = currentResponse.Current.FeelslikeC,
                    FeelsLikeF = currentResponse.Current.FeelslikeF,
                    ConditionText = currentResponse.Current.Condition.Text,
                    ConditionIcon = currentResponse.Current.Condition.Icon,
                    Humidity = currentResponse.Current.Humidity,
                    WindKph = currentResponse.Current.WindKph,
                    WindDir = currentResponse.Current.WindDir,
                    PressureMb = currentResponse.Current.PressureMb,
                    Uv = currentResponse.Current.Uv,
                    IsDay = currentResponse.Current.IsDay == 1
                },

                HourlyForecast = new List<HourlyWeatherInfo>(),
                DailyForecast = new List<DailyWeatherInfo>()
            };

            // Маппинг почасового прогноза
            var now = DateTime.Parse(currentResponse.Location.Localtime);
            var today = now.Date;
            var tomorrow = today.AddDays(1);

            var allHours = new List<ForecastWeatherHour>();
            foreach (var forecastDay in forecastResponse.Forecast.Forecastday)
            {
                allHours.AddRange(forecastDay.Hour);
            }

            var filteredHours = allHours.FindAll(hour =>
            {
                var hourTime = DateTime.Parse(hour.Time);
                return (hourTime.Date == today && hourTime >= now) ||
                       (hourTime.Date == tomorrow);
            });

            foreach (var hour in filteredHours)
            {
                var hourTime = DateTime.Parse(hour.Time);
                viewModel.HourlyForecast.Add(new HourlyWeatherInfo
                {
                    Time = hourTime,
                    TimeDisplay = hourTime.ToString("HH:mm"),
                    TemperatureC = hour.TempC,
                    TemperatureF = hour.TempF,
                    ConditionText = hour.Condition.Text,
                    ConditionIcon = hour.Condition.Icon
                });
            }

            //
            foreach (var forecastDay in forecastResponse.Forecast.Forecastday)
            {
                var date = DateTime.Parse(forecastDay.Date);
                viewModel.DailyForecast.Add(new DailyWeatherInfo
                {
                    Date = date,
                    DayOfWeek = GetRussianDayOfWeek(date.DayOfWeek),
                    MaxTempC = forecastDay.Day.MaxtempC,
                    MinTempC = forecastDay.Day.MintempC,
                    MaxTempF = forecastDay.Day.MaxtempF,
                    MinTempF = forecastDay.Day.MintempF,
                    ConditionText = forecastDay.Day.Condition.Text,
                    ConditionIcon = forecastDay.Day.Condition.Icon,
                    ChanceOfRain = forecastDay.Day.DailyChanceOfRain
                });
            }

            return viewModel;
        }

        private string GetRussianDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "ПН";
                case DayOfWeek.Tuesday:
                    return "ВТ";
                case DayOfWeek.Wednesday:
                    return "СР";
                case DayOfWeek.Thursday:
                    return "ЧТ";
                case DayOfWeek.Friday:
                    return "ПТ";
                case DayOfWeek.Saturday:
                    return "СБ";
                case DayOfWeek.Sunday:
                    return "ВС";
                default:
                    return "";
            }
        }
    }
}