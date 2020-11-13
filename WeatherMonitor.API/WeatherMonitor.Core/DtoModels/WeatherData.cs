using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherMonitor.Core.DtoModels
{
    public class WeatherData
    {
        public int TemperatureCDay { get; set; }
        public int TemperatureFDay { get; set; }
        public int TemperatureCNight { get; set; }
        public int TemperatureFNight { get; set; }
        public int Day { get; set; }
    }
}

