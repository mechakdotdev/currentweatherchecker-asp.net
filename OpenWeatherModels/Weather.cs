namespace CurrentWeatherApp.OpenWeatherModels
{
    public class Weather
    {
        public Weather(string? main)
        {
            Main = main;
        }

        public string? Main { get; }
    }
}
