using MediatR;
using System;
using System.Collections.Generic;
using WeatherMonitor.Core.DtoModels;

namespace WeatherMonitor.Core.Queries
{
    public class GetMonthlyWeatherQuery: IRequest<MonthlyWeatherDto>
    {
        public int Month { get; set; }
        public Guid CityId { get; set; }
    }
}
