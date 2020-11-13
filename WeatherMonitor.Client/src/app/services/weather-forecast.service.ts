import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {WeatherForecastModel} from '../models/weather-forecast.model';
import {environment} from '../../environments/environment';
import { MonthlyWeatherModel } from '../models/monthly-weather.model';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {

  constructor(public httpClient: HttpClient) { }

  getWeatherForecast(cityId: string): Observable<WeatherForecastModel[]> {
    return this.httpClient.get<WeatherForecastModel[]>(environment.apiUrl + 'weatherforecast/getWeatherForTheNext8Days/' + cityId );
  }

  getCurrentWeatherForecast(cityId: string): Observable<WeatherForecastModel> {
    return this.httpClient.get<WeatherForecastModel>(environment.apiUrl + 'weatherforecast/currentWeather/' + cityId);
  }

  getMonthlyWeather(cityId: string, month: number): Observable<MonthlyWeatherModel> {
    return this.httpClient.get<MonthlyWeatherModel>(environment.apiUrl + 'weatherforecast/monthlyWeather/' + cityId + '?month=' + month);
  }
}
