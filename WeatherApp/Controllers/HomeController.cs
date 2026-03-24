using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;
        
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var currentWeather = await _weatherService.GetCurrentWeatherAsync();
                var forecastWeather = await _weatherService.GetForecastWeatherAsync();

                // TODO: передать в View
                return View();
            }
            catch
            {
                return View("Error");
            }
        }
    }
}