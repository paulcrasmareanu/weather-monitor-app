using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherMonitor.Core.Models
{
    public class DailyWeather
    {
        public int Dt { get; set; }
        public TempModel Temp { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double Wind_Speed { get; set; }
        public double Rain { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
    }
}
