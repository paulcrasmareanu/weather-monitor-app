import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlyWeatherChartComponent } from './monthly-weather-chart.component';

describe('MonthlyWeatherComponent', () => {
  let component: MonthlyWeatherChartComponent;
  let fixture: ComponentFixture<MonthlyWeatherChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MonthlyWeatherChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MonthlyWeatherChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
