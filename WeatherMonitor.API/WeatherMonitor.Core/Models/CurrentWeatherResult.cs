using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherMonitor.Core.Models
{
    public class CurrentWeatherResult
    {
        public IEnumerable<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public int Dt { get; set; }
    }
}
