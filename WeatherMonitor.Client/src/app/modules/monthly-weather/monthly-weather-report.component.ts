import { Component, OnInit } from '@angular/core';
import { MonthlyWeatherModel } from 'src/app/models/monthly-weather.model';
import { WeatherForecastService } from 'src/app/services/weather-forecast.service';

@Component({
  selector: 'app-monthly-weather-report',
  templateUrl: './monthly-weather-report.component.html',
  styleUrls: ['./monthly-weather-report.component.scss']
})
export class MonthlyWeatherReportComponent implements OnInit {

  monthlyWeather: MonthlyWeatherModel = null;
  selectedCity: string;
  selectedMonth: number;
  constructor(private weatherService: WeatherForecastService) { }

  ngOnInit(): void {
  }

  onMonthSelect(formValues) {
    if(formValues['month'].value !== null) {
      this.monthlyWeather = null;
      this.weatherService.getMonthlyWeather(formValues['city'].value, formValues['month'].value)
    .subscribe(data =>{ this.monthlyWeather = data });
    return;
    }
    this.selectedMonth = null;
    this.monthlyWeather = null;
    return;
    
  }

}
