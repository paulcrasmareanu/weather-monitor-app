using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Core.QueryHandlers
{
    public class GetWeatherForTheNext8DaysQueryHandler: IRequestHandler<GetWeatherForTheNext8DaysQuery, IEnumerable<WeatherForecastDto>>
    {
        private readonly IOpenWeatherAPIService _openWeatherAPIService;
        private readonly IWeatherMonitorDbContext _weatherMonitorDbContext;
        public GetWeatherForTheNext8DaysQueryHandler(IOpenWeatherAPIService openWeatherAPIService, IWeatherMonitorDbContext weatherMonitorDbContext)
        {
            _weatherMonitorDbContext = weatherMonitorDbContext;
            _openWeatherAPIService = openWeatherAPIService;
        }

        public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForTheNext8DaysQuery request, CancellationToken cancellationToken)
        {
            List<WeatherForecastDto> results = new List<WeatherForecastDto>();
            var locationData = await _weatherMonitorDbContext.Cities.Where(x => x.Id == request.CityId).Select(x => new { x.Lat, x.Lon, x.Name }).FirstOrDefaultAsync();

            var resultFromService = await _openWeatherAPIService.GetWeatherForTheNext8Days(locationData.Lon, locationData.Lat);

            foreach (var item in resultFromService.Daily)
            {
                var result = new WeatherForecastDto
                {
                    CityName = locationData.Name,
                    TemperatureCDay = (int)item.Temp.Day,
                    TemperatureFDay = 32 + (int)((int)item.Temp.Day / 0.5556),
                    TemperatureCNight = (int)item.Temp.Night,
                    TemperatureFNight = 32 + (int)((int)item.Temp.Night / 0.5556),
                    WeatherStatus = ParseWeatherStatusEnum(item.Weather.FirstOrDefault().Main),
                    Humidity = item.Humidity,
                    Pressure = item.Pressure,
                    Wind = (int)item.Wind_Speed,
                    Date = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime,
                    Summary = item.Weather.FirstOrDefault().Description
                };

                results.Add(result);
            }

            return results;
        }

        private WeatherStatus ParseWeatherStatusEnum(string weatherEnum)
        {
            if (Enum.TryParse(weatherEnum, out WeatherStatus result))
            {
                return result;
            }

            return 0;
        }
    }
}
