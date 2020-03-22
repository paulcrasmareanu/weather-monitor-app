# weather-monitor-app

Prerequisite
  1. .NET Core 3.0 (or higher) SDK
  2. Node js 12.16.1 and Angular CLI 9.0.6
  3. SQL Server

Steps for configuring and running the application

  1. API
      - Set the server database name in 'ConnectionStrings' from 'WeatherMonitor.API' project in'appsettings.Development.json'
      - Run from cmd the following command 'dotnet run /seed' from 'WeatherMonitor.API' to populate the database 
      - Run API:
            - From VS IIS Server -> Server host: https://localhost:44380/
            - From cmd 'dotnet run' in 'WeatherMonitor.API' -> Server host: https://localhost:5001/
  
  2. Client
      - In 'WeatherMonitor.Client' project run with cmd the follwowing command 'npm install'
      - Set the back-end url 'apiUrl' variable in 'enviroment.ts' 'from WeatherMonitor.Client/src' if you want run on dotnet command (default url:'https://localhost:44380/' IIS host)
      - Run from cmd the following command 'ng serve' in 'WeatherMonitor.Client'
