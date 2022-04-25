using CurrentWeatherApp.Repositories;
using CurrentWeatherApp.Views.OpenWeatherModels;
using CurrentWeatherApp.WeatherModels;
using Microsoft.AspNetCore.Mvc;

namespace CurrentWeatherApp.Controllers
{
    public class CurrentWeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        
        // Dependency injection
        public CurrentWeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity searchCity)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "CurrentWeather", new { city = searchCity.UserInput });
            }

            return View(searchCity);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            OpenWeatherResponse openWeatherResponse = _weatherRepository.GetCurrentWeather(city).Result;
            City viewModel = new();

            if (openWeatherResponse != null)
            {
                viewModel.Name = openWeatherResponse.Name;
                viewModel.Humidity = openWeatherResponse.Main.Humidity;
                viewModel.Pressure = openWeatherResponse.Main.Pressure;
                viewModel.Temperature = openWeatherResponse.Main.Temp;
                viewModel.Weather = openWeatherResponse.Weather[0].Main;
                viewModel.WindSpeed = openWeatherResponse.Wind.Speed;
            }

            return View(viewModel);
        }
    }
}