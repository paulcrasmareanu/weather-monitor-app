using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Core.Abstracts
{
    public interface IWeatherMonitorDbContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<WeatherForecast> WeatherForecasts { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
