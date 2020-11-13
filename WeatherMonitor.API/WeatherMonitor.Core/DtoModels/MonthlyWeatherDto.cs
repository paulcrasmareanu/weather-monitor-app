using System.Collections.Generic;

namespace WeatherMonitor.Core.DtoModels
{
    public class MonthlyWeatherDto
    {
        public string CityName { get; set; }

        public List<int> MinC { get; set; }

        public List<int> MinF { get; set; }

        public List<int> MaxC { get; set; }

        public List<int> MaxF{ get; set; }

        public List<int> Days { get; set; }

        public MonthlyWeatherDto()
        {
            MinC = new List<int>();
            MinF = new List<int>();
            MaxC = new List<int>();
            MaxF = new List<int>();
            Days = new List<int>();
        }

    }
}