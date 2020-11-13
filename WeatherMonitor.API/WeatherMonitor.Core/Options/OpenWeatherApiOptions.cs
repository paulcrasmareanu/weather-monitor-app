using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherMonitor.Core.Options
{
    public class OpenWeatherApiOptions
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public string Exclude { get; set; }
        public string Units { get; set; }
    }
}
