import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SelectFieldsComponent} from './select-fields/select-fields.component';
import { WeatherForecastListComponent } from './weather-forecast-list/weather-forecast-list.component';
import {FlexModule} from '@angular/flex-layout';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatOptionModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatCardModule} from '@angular/material/card';
import {WeatherForecastComponent} from './weather-forecast.component';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {WeatherForecastRoutingModule} from './weather-forecast-routing.module';



@NgModule({
  declarations: [SelectFieldsComponent, WeatherForecastListComponent, WeatherForecastComponent],
  imports: [
    CommonModule,
    FlexModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatCardModule,
    MatSlideToggleModule,
    WeatherForecastRoutingModule
  ]
})
export class WeatherForecastModule { }
