using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherMonitor.Core.DtoModels
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
