using CurrentWeatherApp.Config;
using CurrentWeatherApp.Views.OpenWeatherModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrentWeatherApp.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        /// <summary>
        /// Get current weather from OpenWeatherMap for a specific location (city)
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        async Task<OpenWeatherResponse> IWeatherRepository.GetCurrentWeather(string city)
        {
            // Connection String
            var openWeatherAPIKey = Constants.OPEN_WEATHER_API_KEY;

            var url = string.Format($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={openWeatherAPIKey}");

            HttpClient client = new();
            using HttpResponseMessage response = await client.GetAsync(url);
            using HttpContent content = response.Content;
            var jsonResponse = await content.ReadAsStringAsync()
                ?? throw new Exception("OpenWeather API response could not be read as string");

            if (response.IsSuccessStatusCode)
            {
                var contentAsJToken = JsonConvert.DeserializeObject<JToken>(jsonResponse)
                     ?? throw new Exception("OpenWeather API failed to deserialize as JToken.");

                var openWeatherResponse = contentAsJToken.ToObject<OpenWeatherResponse>()
                    ?? throw new Exception("OpenWeather Content could not be mapped to object OpenWeatherResponse.");

                return openWeatherResponse;
            }

            return null;
        }
    }
}
