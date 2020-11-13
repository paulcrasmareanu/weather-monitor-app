import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Observable} from 'rxjs';
import {CountryModel} from '../../../models/country.model';
import {CityModel} from '../../../models/city.model';
import {CountryService} from '../../../services/country.service';
import {CityService} from '../../../services/city.service';
import { Months } from 'src/app/models/months.enum';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-select-fields',
  templateUrl: './select-fields.component.html',
  styleUrls: ['./select-fields.component.scss']
})
export class SelectFieldsComponent implements OnInit {

  @Input()  monthSelection = false;
  @Output() selectedCity = new EventEmitter<string>();
  @Output() selectedMonth = new EventEmitter<number>();
  @Output() formValues = new EventEmitter<any>();
  formFilter: FormGroup;

  months = Months;
  countries$ = new Observable<CountryModel[]>();
  cities$ = new Observable<CityModel[]>();
  selectedCountry: string;
  constructor(
    private fb: FormBuilder,
    private countryService: CountryService,
    private cityService: CityService) {
    this.selectedCountry = null;

  }

  ngOnInit(): void {
    this.initForm();
    this.countries$ = this.countryService.getCountries();
  }

  initForm() {
    this.formFilter =  this.fb.group ({
      country: null,
      city: null,
      month: null
    });
  }

  onChange() {
      this.formValues.emit(this.formFilter.controls);
  }

  disableCityDropdown() {
    if(this.formFilter.controls["country"].value === null || this.formFilter.controls["country"].value === '')
      return true;
    return false;
  }

  disableMonthDropdown() {
    if(this.formFilter.controls["city"].value === null || this.formFilter.controls["city"].value === '')
    return true;
  return false;
  }


  onSelectedCountry() {
    this.resetCityDropdown();
    this.cities$ = this.cityService.getCitiesByCountry(this.formFilter.controls['country'].value);
  }

  resetCityDropdown() {
    this.resetMonthDropdown();
    this.formFilter.controls['city'].reset();
    this.formValues.emit(this.formFilter.controls);
  }

  resetMonthDropdown() {
    this.formFilter.controls['month'].reset();
    this.formValues.emit(this.formFilter.controls);
  }

}
