using System;
using System.Collections.Generic;

namespace WeatherApp.Models.ViewModels
{
    public class WeatherViewModel
    {        
        public CurrentWeatherInfo CurrentWeather { get; set; }
                
        public List<HourlyWeatherInfo> HourlyForecast { get; set; }
                
        public List<DailyWeatherInfo> DailyForecast { get; set; }
                
        public LocationInfo Location { get; set; }
    }

    public class CurrentWeatherInfo
    {
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public double FeelsLikeC { get; set; }
        public double FeelsLikeF { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIcon { get; set; }
        public int Humidity { get; set; }
        public double WindKph { get; set; }
        public string WindDir { get; set; }
        public double PressureMb { get; set; }
        public double Uv { get; set; }
        public bool IsDay { get; set; }
    }

    public class HourlyWeatherInfo
    {
        public DateTime Time { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIcon { get; set; }
        public string TimeDisplay { get; set; }
    }

    public class DailyWeatherInfo
    {
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public double MaxTempC { get; set; }
        public double MinTempC { get; set; }
        public double MaxTempF { get; set; }
        public double MinTempF { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIcon { get; set; }
        public int ChanceOfRain { get; set; }
    }

    public class LocationInfo
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string LocalTime { get; set; }
    }
}