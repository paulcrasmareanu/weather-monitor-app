using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.Entities;
using WeatherMonitor.Infrastructure.Data;

namespace WeatherMonitor.Api.Seeder
{
    public class Seeder
    {
        private readonly string _connectionString;

        public Seeder(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SeedData()
        {
            var services = new ServiceCollection();

            services.AddScoped<IWeatherMonitorDbContext, WeatherMonitorDbContext>();

            services.AddDbContext<WeatherMonitorDbContext>((options) =>
            {
                options.UseSqlServer(_connectionString);
            });

            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetService<WeatherMonitorDbContext>();

            context.Database.Migrate();

            AddCountries(context);

            AddCities(context);

            context.SaveChanges();
        }
        private void AddCountries(WeatherMonitorDbContext context)
        {
            var countryList = new List<Country>
            {
                new Country()
            {
                Name = "Romania"
            },
            new Country()
            {
                Name = "Germany"
            },
             new Country()
            {
                Name = "UK"
            }
            };
            foreach (var item in countryList)
            {
                if (!context.Countries.Any(x => x.Name == item.Name))
                {
                    context.Countries.Add(item);
                }
            }
            context.SaveChanges();
        }

        private void AddCities(WeatherMonitorDbContext context)
        {
            var citiesList = new List<City>
            {
                new City()
                {

                Name = "Timisoara",
                Lat = 45.74,
                Lon = 21.2,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Romania")
                },
                new City()
                {
                Name = "Brasov",
                Lat = 45.65,
                Lon = 25.6,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Romania")
                },
                new City()
                {
                Name = "Sibiu",
                Lat = 45.79,
                Lon = 24.14,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Romania")
                },
                new City()
                {

                Name = "Hamburg",
                Lat = 53.55,
                Lon = 9.99,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Germany")
                },
                new City()
                {
                Name = "Berlin",
                Lat = 52.52,
                Lon = 13.4,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Germany")
                },
                new City()
                {
                Name = "Frankfurt",
                Lat = 50.11,
                Lon = 8.68,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Germany")
                },
                new City()
                {

                Name = "London",
                Lat = 51.5,
                Lon = -0.12,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "UK")
                },
                new City()
                {
                Name = "Manchester",
                Lat = 53.47,
                Lon = -2.24,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "UK")
                },
                new City()
                {
                Name = "Oxford",
                Lat = 51.75,
                Lon = -1.25,
                Country = context.Countries.FirstOrDefault(x =>x.Name == "UK")
                }

            };

            foreach (var item in citiesList)
            {
                if (!context.Cities.Any(x => x.Name == item.Name))
                {
                    context.Cities.Add(item);
                }
            }

        }
    }
}
