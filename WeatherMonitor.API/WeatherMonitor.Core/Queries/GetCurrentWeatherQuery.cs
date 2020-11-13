using MediatR;
using System;
using WeatherMonitor.Core.DtoModels;

namespace WeatherMonitor.Core.Queries
{
    public class GetCurrentWeatherQuery: IRequest<WeatherForecastDto>
    {
        public Guid CityId { get; set; }
    }
}
