using MediatR;
using System.Collections.Generic;
using WeatherMonitor.Core.DtoModels;

namespace WeatherMonitor.Core.Queries
{
    public class GetCountriesQuery: IRequest<IEnumerable<CountryDto>>
    {}
}
