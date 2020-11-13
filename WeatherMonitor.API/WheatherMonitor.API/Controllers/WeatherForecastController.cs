using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherMonitor.Core.Commands;
using WeatherMonitor.Core.Queries;

namespace WheatherMonitor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("syncWeatherData")]
        public async Task<IActionResult> SyncWeatherData() 
        {
           var result = await _mediator.Send(new SyncWeatherDataCommand());

           return Ok(result);
        
        }

        [HttpGet("getWeatherForTheNext8Days/{id}")]
        public async Task<IActionResult> GetWeatherForNext8Days(Guid id)
        {
            var results = await _mediator.Send(new GetWeatherForTheNext8DaysQuery {CityId = id});
            return Ok(results);
        }

        [HttpGet("currentWeather/{id}")]
        public async Task<IActionResult> GetCurrentWeather(Guid id)
        {
            var result = await _mediator.Send(new GetCurrentWeatherQuery {CityId = id });

            return Ok(result);
        }

        [HttpGet("monthlyWeather/{id}")]
        public async Task<IActionResult> GetCurrentWeather(Guid id, [FromQuery] int month)
        {
            var result = await _mediator.Send(new GetMonthlyWeatherQuery { CityId = id, Month = month });

            return Ok(result);
        }


    }
}
