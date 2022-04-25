using System.ComponentModel.DataAnnotations;

namespace CurrentWeatherApp.WeatherModels
{
    public class SearchCity
    {
        [Required(ErrorMessage = "This field is missing!")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only text characters (A-Z) are allowed")]
        public string? UserInput { get; set; }
    }
}
