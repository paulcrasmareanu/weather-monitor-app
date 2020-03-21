using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherMonitor.Core.Queries;

namespace WeatherMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController: ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var results = await _mediator.Send(new GetCountriesQuery());

            return Ok(results);
        }
    }
}
