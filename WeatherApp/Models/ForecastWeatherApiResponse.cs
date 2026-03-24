using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models.Common;

namespace WeatherApp.Models
{
    public class ForecastWeatherApiResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
    }    

    public class Forecast
    {
        public List<ForecastDay> Forecastday { get; set; }
    }

    public class ForecastDay
    {
        public string Date { get; set; }
        public Day Day { get; set; }
        public List<Hour> Hour { get; set; }
    }

    public class Day
    {
        public double MaxtempC { get; set; }
        public double MintempC { get; set; }
        public Condition Condition { get; set; }
    }

    public class Hour
    {
        public string Time { get; set; }
        public double TempC { get; set; }
        public Condition Condition { get; set; }
    }
}