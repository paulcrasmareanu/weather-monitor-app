using System;

namespace WeatherMonitor.Core.Entities
{
    public enum WeatherStatus 
    {
        Clouds=1,
        Sun=2,
        Rain=3,
        Clear =4,
        Snow =5,
        Wind =6,
        Drizzle=7,
        Mist=8
    };

    public class WeatherForecast: BaseEntity
    {
        private DateTime _dateTime;
        public DateTime Date { get { return _dateTime; } set { _dateTime = value.Date; }  }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public int TemperatureCDay { get; set; }
        public int TemperatureCNight { get; set; }
        public int MaxC { get; set; }
        public int MinC { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public WeatherStatus WeatherStatus { get; set;}
        public string Summary { get; set; }
    }
}
