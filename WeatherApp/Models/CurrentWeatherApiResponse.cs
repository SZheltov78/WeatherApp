using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models.Common;

namespace WeatherApp.Models
{
    public class CurrentWeatherApiResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }       
    
}