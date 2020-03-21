using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Core.QueryHandlers
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWeatherMonitorDbContext _applicationDbContext;
        public GetCountriesQueryHandler(IMapper mapper, IWeatherMonitorDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var results = await _applicationDbContext.Countries
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();

                return results;
        }
    }
}
