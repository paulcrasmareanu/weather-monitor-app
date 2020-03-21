import {Component, OnInit} from '@angular/core';
import {DayCycle, WeatherForecastModel} from '../../models/weather-forecast.model';
import {WeatherForecastService} from '../../services/weather-forecast.service';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.scss']
})
export class WeatherForecastComponent implements OnInit {

  weatherForecastList: WeatherForecastModel[] = [];
  cityId: string;
  dayCycle: DayCycle = DayCycle.Day;

  constructor(private weatherForecastService: WeatherForecastService) {}

  ngOnInit(): void {
  }

  toggleDayCycle(checked) {
    this.dayCycle = +checked;
    this.getWeatherForecast();
  }

  onSelectedCity(event) {
    this.cityId = event;
    if (this.cityId !== null) {
      this.getWeatherForecast();
      return;
    }
    this.dayCycle = DayCycle.Day;
    this.weatherForecastList = [];
  }

  private getWeatherForecast() {
    this.weatherForecastService.getWeatherForecast(this.cityId, this.dayCycle).subscribe(data => {
      this.weatherForecastList = data;
    });
  }
}
