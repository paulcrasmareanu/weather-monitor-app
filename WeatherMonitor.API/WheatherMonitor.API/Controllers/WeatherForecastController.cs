using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherMonitor.Core.Entities;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeatherForecast(Guid id, [FromQuery] DayCycle dayCycle)
        {
            if (id == null)
            {
                return BadRequest("City id can not be null");
            }
            var results = await _mediator.Send(new GetWeatherForecastQuery
            { 
              CityId = id,
              DayCycle = dayCycle
            });

            return Ok(results);
        }
       
    }
}
