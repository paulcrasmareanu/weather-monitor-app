using AutoMapper;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.AuoMapperProfiles
{
    public class CityDtoProfile: Profile
    {
        public CityDtoProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
