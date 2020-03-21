using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherMonitor.Infrastructure.Data.Migrations
{
    public partial class AddedNewColumnsinWeatherForecastTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayCycle",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeatherStatus",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCycle",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "WeatherStatus",
                table: "WeatherForecasts");
        }
    }
}
