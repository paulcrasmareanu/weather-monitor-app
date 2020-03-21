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
    public class GetCitiesByCountryQueryHandler : IRequestHandler<GetCitiesByCountryQuery, IEnumerable<CityDto>>
    {
        private readonly IWeatherMonitorDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetCitiesByCountryQueryHandler(IWeatherMonitorDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<CityDto>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
        {
            var results = await _applicationDbContext.Cities
                .Where(x => x.CountryId == request.CountryId)
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .OrderBy(x =>x.Name)
                .ToListAsync();

            return results;
        }
    }
}
