import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DayCycle, WeatherForecastModel, WeatherStatus} from '../../../models/weather-forecast.model';

@Component({
  selector: 'app-weather-forecast-list',
  templateUrl: './weather-forecast-list.component.html',
  styleUrls: ['./weather-forecast-list.component.scss']
})
export class WeatherForecastListComponent implements OnInit {

  @Output() OnToggleDayCycle = new EventEmitter<boolean>();
  @Input() weatherForecastList: WeatherForecastModel[];

  WeatherStatus = WeatherStatus;
  DayCycle = DayCycle;
  isToggled = false;

  constructor() { }

  ngOnInit(): void {
  }
  toggleDegreesFormat() {
    this.isToggled =  !this.isToggled;
  }
  toggleDayCycle(checked) {
    this.OnToggleDayCycle.emit(checked);
  }
}
