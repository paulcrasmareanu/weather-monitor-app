using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Romania")
                },
                new City()
                {
                Name = "Brasov",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Romania")
                },
                new City()
                {
                Name = "Sibiu",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Romania")
                },
                new City()
                {

                Name = "Hamburg",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Germany")
                },
                new City()
                {
                Name = "Berlin",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Germany")
                },
                new City()
                {
                Name = "Frankfurt",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "Germany")
                },
                new City()
                {

                Name = "London",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "UK")
                },
                new City()
                {
                Name = "Manchester",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "UK")
                },
                new City()
                {
                Name = "Oxford",
                Country = context.Countries.FirstOrDefault(x =>x.Name == "UK")
                }

            };

            foreach (var item in citiesList)
            {
                if (!context.Cities.Any(x => x.Name == item.Name))
                {
                    context.Cities.Add(item);
                    AddWeatherForecasts(context, item);
                    
                }
            }

        }

        private void AddWeatherForecasts(WeatherMonitorDbContext context, City city)
        {
            var weatherForecastList = new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-4),
                    City = city,
                    TemperatureC = 22,
                    Precipitation = 0,
                    Humidity = 70,
                    Wind = 5,
                    Summary = "Sunny",
                    WeatherStatus = WeatherStatus.Sunny,
                    DayCycle =DayCycle.Day
                },
                 new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-3),
                    City = city,
                    TemperatureC = 15,
                    Precipitation = 55,
                    Humidity = 65,
                    Wind = 25,
                    Summary = "Rainy",
                    WeatherStatus = WeatherStatus.Rainy,
                    DayCycle =DayCycle.Day
                },
                  new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-2),
                    City = city,
                    TemperatureC = 25,
                    Precipitation = 20,
                    Humidity = 74,
                    Wind = 15,
                    Summary = "Cloudy",
                    WeatherStatus = WeatherStatus.Cloudy,
                    DayCycle =DayCycle.Day
                },
                 new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-1),
                    City = city,
                    TemperatureC = 25,
                    Precipitation = 12,
                    Humidity = 74,
                    Wind = 85,
                    Summary = "Windy",
                    WeatherStatus = WeatherStatus.Wind,
                    DayCycle =DayCycle.Day
                },
                new WeatherForecast
                {
                    Date = DateTime.Now,
                    City = city,
                    TemperatureC = 10,
                    Precipitation = 10,
                    Humidity = 71,
                    Wind = 10,
                    Summary = "Sunny",
                    DayCycle = DayCycle.Day,
                    WeatherStatus = WeatherStatus.Sunny,
                },
                 new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-4),
                    City = city,
                    TemperatureC = -5,
                    Precipitation = 60,
                    Humidity = 71,
                    Wind = 10,
                    Summary = "Snowing",
                    DayCycle = DayCycle.Night,
                    WeatherStatus = WeatherStatus.Snow,
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-3),
                    City = city,
                    TemperatureC = 10,
                    Precipitation = 10,
                    Humidity = 71,
                    Wind = 10,
                    Summary = "Clear",
                    DayCycle = DayCycle.Night,
                    WeatherStatus = WeatherStatus.Clear,
                },
               new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-2),
                    City = city,
                    TemperatureC = 12,
                    Precipitation = 0,
                    Humidity = 71,
                    Wind = 72,
                    Summary = "Windy",
                    DayCycle = DayCycle.Night,
                    WeatherStatus = WeatherStatus.Wind,
                },
               new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-1),
                    City = city,
                    TemperatureC = 13,
                    Precipitation = 10,
                    Humidity = 71,
                    Wind = 10,
                    Summary = "Cloudy",
                    DayCycle = DayCycle.Night,
                    WeatherStatus = WeatherStatus.Cloudy,
                },
                 new WeatherForecast
                {
                    Date = DateTime.Now,
                    City = city,
                    TemperatureC = 10,
                    Precipitation = 10,
                    Humidity = 71,
                    Wind = 10,
                    Summary = "Clear",
                    DayCycle = DayCycle.Night,
                    WeatherStatus = WeatherStatus.Clear,
                },
            };
            context.WeatherForecasts.AddRange(weatherForecastList);
        }
    }
}
