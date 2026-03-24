using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class CurrentWeatherApiResponse
    {
        [JsonProperty("location")]
        public CurrentWeatherLocation Location { get; set; }

        [JsonProperty("current")]
        public CurrentWeatherData Current { get; set; }
    }

    public class CurrentWeatherLocation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("localtime")]
        public string Localtime { get; set; }
    }

    public class CurrentWeatherData
    {
        [JsonProperty("temp_c")]
        public double TempC { get; set; }

        [JsonProperty("temp_f")]
        public double TempF { get; set; }

        [JsonProperty("is_day")]
        public int IsDay { get; set; }

        [JsonProperty("condition")]
        public CurrentWeatherCondition Condition { get; set; }

        [JsonProperty("wind_kph")]
        public double WindKph { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }

        [JsonProperty("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("feelslike_c")]
        public double FeelslikeC { get; set; }

        [JsonProperty("feelslike_f")]
        public double FeelslikeF { get; set; }

        [JsonProperty("uv")]
        public double Uv { get; set; }
    }

    public class CurrentWeatherCondition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}