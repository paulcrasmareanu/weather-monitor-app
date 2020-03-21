using System;

namespace WeatherMonitor.Core.Entities
{
    public enum WeatherStatus 
    {
        Cloudy=1,
        Sunny=2,
        Rainy=3,
        Clear =4,
        Snow =5,
        Wind =6
    };
    public enum DayCycle 
    {
        Day =0,
        Night =1
    }
    public class WeatherForecast: BaseEntity
    {
        private DateTime _dateTime;
        public DateTime Date { get { return _dateTime; } set { _dateTime = value.Date; }  }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public int TemperatureC { get; set; }
        public int Precipitation { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public WeatherStatus WeatherStatus { get; set;}
        public DayCycle DayCycle { get; set; }
        public string Summary { get; set; }
    }
}
