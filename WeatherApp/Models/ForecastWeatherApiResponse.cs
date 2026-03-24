using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.Models
{
    public class ForecastWeatherApiResponse
    {
        [JsonProperty("forecast")]
        public ForecastWeatherForecast Forecast { get; set; }
    }

    public class ForecastWeatherForecast
    {
        [JsonProperty("forecastday")]
        public List<ForecastWeatherDay> Forecastday { get; set; }
    }

    public class ForecastWeatherDay
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("day")]
        public ForecastWeatherDayData Day { get; set; }

        [JsonProperty("hour")]
        public List<ForecastWeatherHour> Hour { get; set; }
    }

    public class ForecastWeatherDayData
    {
        [JsonProperty("maxtemp_c")]
        public double MaxtempC { get; set; }

        [JsonProperty("maxtemp_f")]
        public double MaxtempF { get; set; }

        [JsonProperty("mintemp_c")]
        public double MintempC { get; set; }

        [JsonProperty("mintemp_f")]
        public double MintempF { get; set; }

        [JsonProperty("condition")]
        public ForecastWeatherCondition Condition { get; set; }

        [JsonProperty("daily_chance_of_rain")]
        public int DailyChanceOfRain { get; set; }
    }

    public class ForecastWeatherHour
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("temp_c")]
        public double TempC { get; set; }

        [JsonProperty("temp_f")]
        public double TempF { get; set; }

        [JsonProperty("condition")]
        public ForecastWeatherCondition Condition { get; set; }
    }

    public class ForecastWeatherCondition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}