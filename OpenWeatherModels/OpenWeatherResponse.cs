namespace CurrentWeatherApp.Views.OpenWeatherModels
{
    public class OpenWeatherResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public List<Weather> Weather { get; set; }

    }
}
