namespace CurrentWeatherApp.OpenWeatherModels
{
    public class OpenWeatherResponse
    {
        public OpenWeatherResponse(List<Weather> weather, Wind wind, Main main, string? name)
        {
            Weather = weather;
            Wind = wind;
            Main = main;
            Name = name;
        }

        public string? Name { get; }
        public Main Main { get; }
        public Wind Wind { get; }
        public List<Weather> Weather { get; }

    }
}
