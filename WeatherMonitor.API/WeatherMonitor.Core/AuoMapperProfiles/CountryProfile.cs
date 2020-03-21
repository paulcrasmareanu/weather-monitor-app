using AutoMapper;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.AuoMapperProfiles
{
    public class CountryProfile: Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
