import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WeatherForecastListComponent } from './weather-forecast-list/weather-forecast-list.component';
import {WeatherForecastComponent} from './weather-forecast.component';
import {WeatherForecastRoutingModule} from './weather-forecast-routing.module';
import { CurrentWeatherComponent } from './current-weather/current-weather.component';
import { SharedModule } from 'src/app/shared/modules/shared.module';



@NgModule({
  declarations: [WeatherForecastListComponent, WeatherForecastComponent, CurrentWeatherComponent],
  imports: [
    CommonModule,
    SharedModule,
    WeatherForecastRoutingModule,

  ]
})
export class WeatherForecastModule { }
