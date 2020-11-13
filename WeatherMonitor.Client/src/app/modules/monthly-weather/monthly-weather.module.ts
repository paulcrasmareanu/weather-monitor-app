import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthlyWeatherChartComponent } from './monthly-weather-chart/monthly-weather-chart.component';
import { MonthlyWeatherRoutingModule } from './monthly-weather-routing.module';
import { ChartsModule, MDBBootstrapModule, WavesModule } from 'angular-bootstrap-md';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { MonthlyWeatherReportComponent } from './monthly-weather-report.component';



@NgModule({
  declarations: [MonthlyWeatherChartComponent, MonthlyWeatherReportComponent],
  imports: [
    MDBBootstrapModule.forRoot(),
    CommonModule,
    SharedModule,
    MonthlyWeatherRoutingModule,
    ChartsModule,
    WavesModule,
  ]
})
export class MonthlyWeatherModule { }
