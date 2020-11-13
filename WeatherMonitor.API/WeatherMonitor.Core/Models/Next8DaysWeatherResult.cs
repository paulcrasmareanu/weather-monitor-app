using System.Collections.Generic;

namespace WeatherMonitor.Core.Models
{
    public class Next8DaysWeatherResult
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public IEnumerable<DailyWeather> Daily { get; set; }

    }
}
