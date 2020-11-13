using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Models;

namespace WeatherMonitor.Core.Queries
{
    public class GetWeatherForTheNext8DaysQuery: IRequest<IEnumerable<WeatherForecastDto>>
    {
        public Guid CityId { get; set; }
    }
}
