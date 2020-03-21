1. Add Migration

-- Add-Migration MY_MIGRATION_NAME -StartupProject WeatherMonitor.API -Project WeatherMonitor.Infrastructure -OutputDir Data\Migrations --

2. Remove Migration

-- Remove-Migration -StartupProject WeatherMonitor.API -Project WeatherMonitor.Infrastructure --

3. Update-Database

-- Update-Database -s WeatherMonitor.API --