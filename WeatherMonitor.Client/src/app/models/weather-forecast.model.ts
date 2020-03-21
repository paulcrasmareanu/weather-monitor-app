export enum DayCycle {
  Day = 0,
  Night = 1
}

export enum WeatherStatus {
  Cloudy = 1,
  Sunny = 2,
  Rainy = 3,
  Clear = 4,
  Snow = 5,
  Wind = 6
}

export class WeatherForecastModel {
  date: Date;
  temperatureC: number;
  temperatureF: number;
  precipitation: number;
  humidity: number;
  wind: number;
  weatherStatus: WeatherStatus;
  dayCycle: DayCycle;
  summary: string;
}
