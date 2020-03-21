import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CityModel} from '../models/city.model';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(public httpClient: HttpClient) { }

  getCitiesByCountry(countryId: string): Observable<CityModel[]> {
    return this.httpClient.get<CityModel[]>(environment.apiUrl + 'city/' + countryId);
  }
}
