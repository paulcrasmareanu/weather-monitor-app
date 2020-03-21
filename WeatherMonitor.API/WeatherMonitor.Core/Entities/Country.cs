using System.Collections.Generic;

namespace WeatherMonitor.Core.Entities
{
    public class Country: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
