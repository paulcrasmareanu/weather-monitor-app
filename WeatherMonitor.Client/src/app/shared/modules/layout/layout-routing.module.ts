import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {LayoutComponent} from './layout.component';
import {PageNotFoundComponent} from '../../../components/page-not-found/page-not-found.component';
import {HomeComponent} from '../../../components/home/home.component';


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'home',
        component:  HomeComponent
      },
      {
        path: 'weather-forecast',
        loadChildren: () => import('../../../modules/weather-forecast/weather-forecast.module').then(m => m.WeatherForecastModule)
      },
      {
        path: 'monthly-weather',
        loadChildren: () => import('../../../modules/monthly-weather/monthly-weather.module').then(m => m.MonthlyWeatherModule)
      },
      {
        path: '',
        redirectTo:  '/home',
        pathMatch: 'full'
      },
      {
        path: '**',
        component: PageNotFoundComponent
      },
    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule {
}
