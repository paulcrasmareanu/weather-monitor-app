using System;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.DtoModels
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public int Precipitation { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public WeatherStatus WeatherStatus { get; set; }
        public DayCycle DayCycle { get; set; }
        public string Summary { get; set; }
    }
}
