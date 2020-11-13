import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlyWeatherReportComponent } from './monthly-weather-report.component';

describe('MonthlyWeatherReportComponent', () => {
  let component: MonthlyWeatherReportComponent;
  let fixture: ComponentFixture<MonthlyWeatherReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MonthlyWeatherReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MonthlyWeatherReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
