import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CountryModel} from '../models/country.model';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(public httpClient: HttpClient) { }

  getCountries(): Observable<CountryModel[]> {
   return  this.httpClient.get<CountryModel[]>(environment.apiUrl + 'country');
  }
}
