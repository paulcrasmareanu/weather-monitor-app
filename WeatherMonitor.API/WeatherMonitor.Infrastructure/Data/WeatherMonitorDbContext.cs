using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.Entities;

namespace WeatherMonitor.Infrastructure.Data
{
    public class WeatherMonitorDbContext :DbContext, IWeatherMonitorDbContext
    {
        public WeatherMonitorDbContext(DbContextOptions<WeatherMonitorDbContext> options): base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
