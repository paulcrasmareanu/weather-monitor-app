import { getLocaleDayNames } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MonthlyWeatherModel } from 'src/app/models/monthly-weather.model';

@Component({
  selector: 'app-monthly-weather-chart',
  templateUrl: './monthly-weather-chart.component.html',
  styleUrls: ['./monthly-weather-chart.component.scss']
})
export class MonthlyWeatherChartComponent implements OnInit {

  @Input() monthlyWeather: MonthlyWeatherModel = null;
  @Input() selectedMonth: number;
  isCelsius: boolean = true;
  public chartDatasets: Array<any> = [
    { data: [0], label: 'Max Temp' },
    { data: [0], label: 'Min Temp' }
  ];


  public chartLabels: Array<any> = [0];


  public chartType: string = 'line';

 
  public chartColors: Array<any> = [
    {
      backgroundColor: 'rgba(105, 0, 132, .2)',
      borderColor: 'rgba(200, 99, 132, .7)',
      borderWidth: 2,
    },
    {
      backgroundColor: 'rgba(0, 137, 132, .2)',
      borderColor: 'rgba(0, 10, 130, .7)',
      borderWidth: 2,
    }
  ];

  public chartOptions: any = {
    responsive: true
  };

  constructor() { }

  ngOnInit(): void {
    setTimeout(() => {

      this.chartLabels = this.getDays(this.selectedMonth, new Date().getFullYear());
      this.initData();
      }, 100);
  }

  initData() {
    if(this.isCelsius)
    {
      this.chartDatasets= [
      
        { data: this.monthlyWeather.maxC, label: 'Max Temp' },
        { data: this.monthlyWeather.minC, label: 'Min Temp' }
      
      ];
      return;
    }
    this.chartDatasets= [
      
      { data: this.monthlyWeather.maxF, label: 'Max Temp' },
      { data: this.monthlyWeather.minF, label: 'Min Temp' }
    
    ];
  }

  toggleDegreesFormat() {

    this.isCelsius = !this.isCelsius;
    this.initData();
  }

  public chartClicked(e: any): void { }
  public chartHovered(e: any): void { }

  private getDays(month, year) {
    let days = []
    let nrOfdays = new Date(year, month, 0).getDate();

    for(let i = this.monthlyWeather.days[0]; i<= +nrOfdays; i++)
    {
      days.push(i);

    }
    return days;
  }

}
