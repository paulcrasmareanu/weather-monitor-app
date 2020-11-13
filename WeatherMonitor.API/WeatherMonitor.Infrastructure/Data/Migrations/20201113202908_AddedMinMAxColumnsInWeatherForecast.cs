using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherMonitor.Infrastructure.Data.Migrations
{
    public partial class AddedMinMAxColumnsInWeatherForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxC",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinC",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxC",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "MinC",
                table: "WeatherForecasts");
        }
    }
}
