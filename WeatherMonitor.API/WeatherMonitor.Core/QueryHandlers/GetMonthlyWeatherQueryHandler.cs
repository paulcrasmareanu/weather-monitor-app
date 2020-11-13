using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.DtoModels;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Core.QueryHandlers
{
    public class GetMonthlyWeatherQueryHandler : IRequestHandler<GetMonthlyWeatherQuery, MonthlyWeatherDto>
    {
        private readonly IWeatherMonitorDbContext _applicationDbContext;
        public GetMonthlyWeatherQueryHandler(IWeatherMonitorDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<MonthlyWeatherDto> Handle(GetMonthlyWeatherQuery request, CancellationToken cancellationToken)
        {
            MonthlyWeatherDto monthlyWeatherDto = new MonthlyWeatherDto();
            var result = await _applicationDbContext.WeatherForecasts
                .Include(x => x.City)
                .Where(x => x.CityId == request.CityId && x.Date.Month == request.Month)
                .ToListAsync();

            if (result.Count() > 0)
            {
                monthlyWeatherDto.CityName = result.Where(x => x.CityId == request.CityId).FirstOrDefault().City.Name;

                foreach (var item in result)
                {
                    monthlyWeatherDto.Days.Add(item.Date.Day);
                    monthlyWeatherDto.MaxC.Add(item.MaxC);
                    monthlyWeatherDto.MinC.Add(item.MinC);
                    monthlyWeatherDto.MaxF.Add(item.TemperatureCDay + 32 + (int)(item.MaxC / 0.5556));
                    monthlyWeatherDto.MinF.Add(item.TemperatureCNight + 32 + (int)(item.MinC / 0.5556));
                }
            }
          
            return monthlyWeatherDto;
        }
    }
}
