using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.Commands;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Models;
using WeatherMonitor.Core.Entities;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace WeatherMonitor.Core.CommandHandlers
{
    public class SyncWeatherDataCommandHandler : IRequestHandler<SyncWeatherDataCommand, bool>
    {
        private readonly IOpenWeatherAPIService _openWeatherAPIService;
        private readonly IWeatherMonitorDbContext _weatherMonitorDbContext;
        private readonly IMapper _mapper;
        public SyncWeatherDataCommandHandler(IOpenWeatherAPIService openWeatherAPIService, IWeatherMonitorDbContext weatherMonitorDbContext, IMapper mapper)
        {
            _openWeatherAPIService = openWeatherAPIService;
            _weatherMonitorDbContext = weatherMonitorDbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SyncWeatherDataCommand request, CancellationToken cancellationToken)
        {
            var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(7);

            var isSync = _weatherMonitorDbContext.WeatherForecasts.Any(x => x.Date == currentDate);

            if (isSync)
            {
               return true;
            }

            var cities = _weatherMonitorDbContext.Cities.ToList();

            foreach(var city in cities)
            {
                var resultFromService = await _openWeatherAPIService.GetWeatherForTheNext8Days(city.Lon, city.Lat);

                var weatherDtos = BuildWeatherForecastDtoList(resultFromService);

                var weatherForecastList = _mapper.Map<List<WeatherForecast>>(weatherDtos);

                weatherForecastList.ForEach(x => x.CityId = city.Id);

                var lastWeatherDate = await _weatherMonitorDbContext.WeatherForecasts
                    .Where(x => x.CityId == city.Id)
                    .OrderByDescending(x => x.Date)
                    .Select(x => x.Date)
                    .FirstOrDefaultAsync();

                var test = weatherForecastList.Where(x => x.Date > lastWeatherDate);
                _weatherMonitorDbContext.WeatherForecasts.AddRange(test);
                
            }

            await _weatherMonitorDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }

        private List<WeatherForecastDto> BuildWeatherForecastDtoList(Next8DaysWeatherResult resultFromService)
        {
            List<WeatherForecastDto> results = new List<WeatherForecastDto>();
            foreach (var item in resultFromService.Daily)
            {
                var result = new WeatherForecastDto
                {
                    TemperatureCDay = (int)item.Temp.Day,
                    TemperatureCNight = (int)item.Temp.Night,
                    MaxC = (int)item.Temp.Max,
                    MinC = (int)item.Temp.Min,
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
