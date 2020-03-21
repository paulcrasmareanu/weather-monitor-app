using MediatR;
using System;
using System.Collections.Generic;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.Queries
{
    public class GetWeatherForecastQuery: IRequest<IEnumerable<WeatherForecastDto>>
    {
        public Guid CityId { get; set; }
        public DayCycle DayCycle { get; set; }
    }
}
