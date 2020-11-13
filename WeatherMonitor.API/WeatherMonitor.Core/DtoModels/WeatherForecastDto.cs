using System;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.DtoModels
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public string  CityName { get; set; }
        public int TemperatureCDay { get; set; }
        public int TemperatureFDay { get; set; }
        public int TemperatureCNight { get; set; }
        public int TemperatureFNight { get; set; }
        public int MaxC { get; set; }
        public int MinC { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public WeatherStatus WeatherStatus { get; set; }
        public string Summary { get; set; }
    }
}
