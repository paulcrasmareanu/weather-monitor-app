using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherMonitor.Infrastructure.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCycle",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "Precipitation",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "TemperatureC",
                table: "WeatherForecasts");

            migrationBuilder.AddColumn<int>(
                name: "Pressure",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureCDay",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureCNight",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "TemperatureCDay",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "TemperatureCNight",
                table: "WeatherForecasts");

            migrationBuilder.AddColumn<int>(
                name: "DayCycle",
                table: "WeatherForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Precipitation",
                table: "WeatherForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureC",
                table: "WeatherForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
