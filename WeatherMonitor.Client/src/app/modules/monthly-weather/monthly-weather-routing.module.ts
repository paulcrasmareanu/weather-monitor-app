import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { MonthlyWeatherReportComponent } from './monthly-weather-report.component';

const routes: Routes = [
  {
    path: '',
    component: MonthlyWeatherReportComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonthlyWeatherRoutingModule {
}
