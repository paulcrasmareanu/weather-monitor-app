using AutoMapper;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherMonitor.Core;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Core.Options;
using WeatherMonitor.Core.Services;
using WeatherMonitor.Infrastructure.Data;

[assembly: FunctionsStartup(typeof(WeatherMonitor.AzureFunctions.Startup))]
namespace WeatherMonitor.AzureFunctions
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = configBuilder.Build();

            builder.Services.AddAutoMapper(typeof(AssemblyMarker), typeof(Startup));
            builder.Services.AddMediatR(typeof(AssemblyMarker));
            builder.Services.AddScoped<IWeatherMonitorDbContext, WeatherMonitorDbContext>();
            builder.Services.AddScoped<IOpenWeatherAPIService, OpenWeatherAPIService>();
            builder.Services.Configure<OpenWeatherApiOptions>(config.GetSection("OpenWeatherApi"));

            builder.Services.AddDbContext<WeatherMonitorDbContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, config.GetConnectionString("WeatherMonitorContext")));
        }
    }
}
