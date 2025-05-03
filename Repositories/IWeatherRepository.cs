using CurrentWeatherApp.OpenWeatherModels;

namespace CurrentWeatherApp.Repositories
{
    public interface IWeatherRepository
    {
        Task<OpenWeatherResponse?> GetCurrentWeather(string city);
    }
}
