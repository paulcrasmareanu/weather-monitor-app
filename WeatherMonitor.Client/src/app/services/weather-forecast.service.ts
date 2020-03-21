import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {DayCycle, WeatherForecastModel} from '../models/weather-forecast.model';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {

  constructor(public httpClient: HttpClient) { }

  getWeatherForecast(cityId: string, dayCycle: DayCycle): Observable<WeatherForecastModel[]> {
    return this.httpClient.get<WeatherForecastModel[]>(environment.apiUrl + 'weatherforecast/' + cityId + '?dayCycle=' + dayCycle );
  }
}
