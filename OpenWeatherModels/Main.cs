namespace CurrentWeatherApp.OpenWeatherModels
{
    public class Main
    {
        public Main(double temp, int pressure, int humidity)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
        }

        public double Temp { get; }
        public int Pressure { get; }
        public int Humidity { get; }
    }
}
