using System.Threading.Tasks;
using WeatherMonitor.Core.Models;

namespace WeatherMonitor.Core.Abstracts
{
    public interface IOpenWeatherAPIService
    {
        Task<CurrentWeatherResult> GetCurrentWeather(string locationName);
        Task<Next8DaysWeatherResult> GetWeatherForTheNext8Days(double lon, double lat);
    }
}
