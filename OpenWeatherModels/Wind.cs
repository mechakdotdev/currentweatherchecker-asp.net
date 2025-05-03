namespace CurrentWeatherApp.OpenWeatherModels
{
    public class Wind
    {
        public Wind(double speed)
        {
            Speed = speed;
        }

        public double Speed { get; }
    }
}
