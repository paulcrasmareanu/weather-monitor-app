using AutoMapper;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.AuoMapperProfiles
{
    public class WeatherForecastProfile: Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDto>()
                .ForMember(x => x.TemperatureF, y => y.MapFrom(z => 32 + (int)(z.TemperatureC / 0.5556)));
        }
    }
}
