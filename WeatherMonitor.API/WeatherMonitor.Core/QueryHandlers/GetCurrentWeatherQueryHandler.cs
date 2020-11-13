using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Core.QueryHandlers
{
    public class GetCurrentWeatherQueryHandler : IRequestHandler<GetCurrentWeatherQuery, WeatherForecastDto>
    {
        private readonly IOpenWeatherAPIService _openWeatherAPIService;
        private readonly IWeatherMonitorDbContext _applicationDbContext;
         
        public GetCurrentWeatherQueryHandler(IOpenWeatherAPIService openWeatherAPIService, IWeatherMonitorDbContext applicationDbContext)
        {
            _openWeatherAPIService = openWeatherAPIService;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<WeatherForecastDto> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            var locationName = _applicationDbContext.Cities
                .Where(x => x.Id == request.CityId)
                .Select(y => y.Name)
                .SingleOrDefault();

            var resultFromService = await _openWeatherAPIService.GetCurrentWeather(locationName);

            var result = new WeatherForecastDto
            {
                CityName = locationName,
                TemperatureCDay = (int)resultFromService.Main.Temp,
                TemperatureFDay = 32 + (int)(resultFromService.Main.Temp / 0.5556),
                WeatherStatus = ParseWeatherStatusEnum(resultFromService.Weather.FirstOrDefault().Main),
                Humidity = (int)resultFromService.Main.Humidity,
                Wind = (int)resultFromService.Wind.Speed,
                Date = DateTimeOffset.FromUnixTimeSeconds(resultFromService.Dt).DateTime,
                Summary = resultFromService.Weather.FirstOrDefault().Description
            };

            return result;
        }

        private WeatherStatus ParseWeatherStatusEnum(string weatherEnum)  
        {
            if(Enum.TryParse(weatherEnum, out WeatherStatus result))
            {
                return result;
            }

            return 0;
        }
    }
}
