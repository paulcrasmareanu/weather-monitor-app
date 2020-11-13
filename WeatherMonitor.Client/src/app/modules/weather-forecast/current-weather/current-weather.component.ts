import { Component, Input, OnInit } from '@angular/core';
import { WeatherForecastModel, WeatherStatus } from '../../../models/weather-forecast.model';

@Component({
  selector: 'app-current-weather',
  templateUrl: './current-weather.component.html',
  styleUrls: ['./current-weather.component.scss']
})
export class CurrentWeatherComponent implements OnInit {

  @Input() currentWeather: WeatherForecastModel;
  WeatherStatus = WeatherStatus;
  
  isToggled = false;
  constructor() { }

  ngOnInit(): void {
  }

  toggleDegreesFormat() {
    this.isToggled =  !this.isToggled;
  }

}
