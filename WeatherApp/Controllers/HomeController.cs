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
        private readonly IWeatherViewModelService _weatherVMService;
        
        public HomeController(IWeatherViewModelService weatherVMService)
        {
            _weatherVMService = weatherVMService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _weatherVMService.GetWeatherViewModelAsync();                
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}