using AutoMapper;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;
using WeatherMonitor.Core.Models;

namespace WeatherMonitor.Core.AuoMapperProfiles
{
    public class WeatherForecastProfile: Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecastDto, WeatherForecast>()
                .ForMember(x => x.CityId, y=> y.Ignore())
                .ForMember(x => x.City, y => y.Ignore());
        }
    }
}
