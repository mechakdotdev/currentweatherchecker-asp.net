using CurrentWeatherApp.Repositories;
using CurrentWeatherApp.WeatherModels;
using Microsoft.AspNetCore.Mvc;

namespace CurrentWeatherApp.Controllers;

public class CurrentWeatherController : Controller
{
    private readonly IWeatherRepository _weatherRepository;

    public CurrentWeatherController(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    [HttpGet]
    public IActionResult SearchCity()
    {
        return View(new SearchCity());
    }

    [HttpPost]
    public IActionResult SearchCity(SearchCity searchCity)
    {
        if (!ModelState.IsValid)
            return View(searchCity);

        return RedirectToAction(nameof(City), new { city = searchCity.UserInput });
    }

    [HttpGet]
    public async Task<IActionResult> City(string city)
    {
        var response = await _weatherRepository.GetCurrentWeather(city);
                
        if (response is null) return NotFound();

        var viewModel = new City
        {
            Name = response.Name,
            Humidity = response.Main.Humidity,
            Pressure = response.Main.Pressure,
            Temperature = response.Main.Temp,
            Weather = response.Weather.First().Main,
            WindSpeed = response.Wind.Speed
        };

        return View(viewModel);
    }
}