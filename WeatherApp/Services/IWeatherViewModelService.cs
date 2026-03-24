using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models.ViewModels;

namespace WeatherApp.Services
{
    public interface IWeatherViewModelService
    {
        Task<WeatherViewModel> GetWeatherViewModelAsync();
    }
}
