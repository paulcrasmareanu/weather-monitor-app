using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.Models;
using WeatherMonitor.Core.Options;

namespace WeatherMonitor.Core.Services
{
    public class OpenWeatherAPIService : IOpenWeatherAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherApiOptions _apiOptions;

        public OpenWeatherAPIService(IOptions<OpenWeatherApiOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
            _httpClient = new HttpClient();
        }
        public async Task<Next8DaysWeatherResult> GetWeatherForTheNext8Days(double lon, double lat)
        {
            var url = 
                _apiOptions.BaseUrl + "onecall?"
                + "lon=" + lon 
                + "&appid=" + _apiOptions.ApiKey 
                + "&units="+ _apiOptions.Units 
                + "&exclude=" + _apiOptions.Exclude 
                + "&lat=" + lat;

            var response = await _httpClient.GetAsync(url);

            var result = JsonConvert.DeserializeObject<Next8DaysWeatherResult>(await response.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<CurrentWeatherResult> GetCurrentWeather(string locationName)
        {
            var url = 
                _apiOptions.BaseUrl + "weather?"
                + "q=" + locationName 
                + "&appid="+ _apiOptions.ApiKey 
                + "&units=" + _apiOptions.Units;

            var response = await _httpClient.GetAsync(url);

            var result = JsonConvert.DeserializeObject<CurrentWeatherResult>(await response.Content.ReadAsStringAsync());

            return result;

        }
    }
}
