import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {Observable} from 'rxjs';
import {CountryModel} from '../../../models/country.model';
import {CityModel} from '../../../models/city.model';
import {CountryService} from '../../../services/country.service';
import {CityService} from '../../../services/city.service';

@Component({
  selector: 'app-select-fields',
  templateUrl: './select-fields.component.html',
  styleUrls: ['./select-fields.component.scss']
})
export class SelectFieldsComponent implements OnInit {

  countries$ = new Observable<CountryModel[]>();
  cities$ = new Observable<CityModel[]>();
  selectedCountry: string;
  @Output() selectedCity = new EventEmitter<string>();
  constructor(
    private countryService: CountryService,
    private cityService: CityService) {
    this.selectedCountry = null;
  }

  ngOnInit(): void {
    this.countries$ = this.countryService.getCountries();
  }

  onSelectedCountry(countryId) {
    this.selectedCity.emit(null);
    this.cities$ = this.cityService.getCitiesByCountry(countryId);
  }

  onSelectedCity(cityId) {
    this.selectedCity.emit(cityId);
  }

}
