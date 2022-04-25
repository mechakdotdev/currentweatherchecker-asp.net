using System.ComponentModel.DataAnnotations;

namespace CurrentWeatherApp.WeatherModels
{
    public class City
    {
        public string? Name { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public string? Weather { get; set; }
    }
}
