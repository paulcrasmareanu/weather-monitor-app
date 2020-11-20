using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;
using WeatherMonitor.Core.Commands;

namespace WeatherMonitor.AzureFunctions
{
    public class SyncOpenWeatherApiFunction
    {
        private readonly IMediator _mediator;
        public SyncOpenWeatherApiFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("SyncOpenWeatherApiFunction")]
        public async Task<bool> RunSync([ActivityTrigger] bool startTrigger) 
        {
            var result =  await _mediator.Send(new SyncWeatherDataCommand());

            return result;
        }
    }
}
