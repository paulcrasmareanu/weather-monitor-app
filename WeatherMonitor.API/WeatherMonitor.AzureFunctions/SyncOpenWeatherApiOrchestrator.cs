using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

namespace WeatherMonitor.AzureFunctions
{
    public class SyncOpenWeatherApiOrchestrator
    {
        [FunctionName("SyncOpenWeatherApiOrchestrator")]
        public static async Task RunOrchestrator(
           [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            bool result = await context.CallActivityAsync<bool>("SyncOpenWeatherApiFunction", true);
        }
    }
}
