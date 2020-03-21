using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitiesByCountry(Guid id)
        {
            if(id == null)
            {
                return BadRequest("Country Id can not be null");
            }

            var results = await _mediator.Send(new GetCitiesByCountryQuery
            {
                CountryId = id
            });

            return Ok(results);
        }
    }
}