using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace WeatherMonitor.AzureFunctions
{
    public static class SyncOpenWeatherApiTimerTrigger
    {
        [FunctionName("SyncOpenWeatherApiTimerTrigger")]
        public static async Task Run(
            [TimerTrigger("0 0 8 * * *")]TimerInfo myTimer,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string instanceId = await starter.StartNewAsync("SyncOpenWeatherApiOrchestrator", null);

            log.LogInformation($"SyncOpenWeatherApiTimerTrigger function with Instance ID: " + instanceId + "executed at: {DateTime.Now}");
        }
    }
}
