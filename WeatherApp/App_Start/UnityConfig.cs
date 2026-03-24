using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WeatherApp.Services;

namespace WeatherApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IWeatherService, WeatherService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}