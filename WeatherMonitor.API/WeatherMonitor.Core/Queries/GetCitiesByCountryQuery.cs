using MediatR;
using System;
using System.Collections.Generic;
using WeatherMonitor.Core.DtoModels;

namespace WeatherMonitor.Core.Queries
{
    public class GetCitiesByCountryQuery: IRequest<IEnumerable<CityDto>>
    {
        public Guid CountryId { get; set; }
    }
}
