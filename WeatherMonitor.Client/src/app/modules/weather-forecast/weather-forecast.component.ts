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
  currentWeatherForecast: WeatherForecastModel = null;
  cityId: string;

  constructor(private weatherForecastService: WeatherForecastService) {}

  ngOnInit(): void {
  }

 
  onSelectedCity(formValues) {
    this.cityId = formValues['city'].value;
    console.log(this.cityId)
    if (this.cityId !== null) {
      this.getCurrentWeather();
      this.getWeatherForecast();
      return;
    }
    this.weatherForecastList = [];
    this.currentWeatherForecast = null;
  }

  private getWeatherForecast() {
    this.weatherForecastService.getWeatherForecast(this.cityId).subscribe(data => {
      this.weatherForecastList = data;
    });
  }

  private getCurrentWeather() {
    this.weatherForecastService.getCurrentWeatherForecast(this.cityId).subscribe(data => {
      this.currentWeatherForecast = data;
    });
  }
}
