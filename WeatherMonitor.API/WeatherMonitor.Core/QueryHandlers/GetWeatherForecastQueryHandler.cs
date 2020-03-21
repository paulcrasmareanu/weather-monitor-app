using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Core.QueryHandlers
{
    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastDto>>
    {
        private readonly IWeatherMonitorDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetWeatherForecastQueryHandler(IWeatherMonitorDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.WeatherForecasts
                .Where(x => x.CityId == request.CityId && x.Date.Date < DateTime.Now.Date && x.DayCycle== request.DayCycle)
                .ProjectTo<WeatherForecastDto>(_mapper.ConfigurationProvider)
                .OrderBy(x=> x.Date)
                .ToListAsync();

            return result;
        }
    }
}
