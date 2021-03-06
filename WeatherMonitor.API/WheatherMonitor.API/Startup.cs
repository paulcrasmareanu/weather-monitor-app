using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherMonitor.Core;
using WeatherMonitor.Core.Abstracts;
using WeatherMonitor.Infrastructure.Data;

namespace WheatherMonitor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AssemblyMarker), typeof(Startup));

            services.AddMediatR(typeof(AssemblyMarker));

            services.AddScoped<IWeatherMonitorDbContext, WeatherMonitorDbContext>();

            services
                .AddDbContext<WeatherMonitorDbContext>(options =>
                    options
                    .UseSqlServer(Configuration
                    .GetConnectionString("WeatherMonitorContext")));

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });

            services.AddControllers();

  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("DefaultPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
