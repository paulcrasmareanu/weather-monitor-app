export enum DayCycle {
  Day = 0,
  Night = 1
}

export enum WeatherStatus {
  Clouds = 1,
  Sun = 2,
  Rain = 3,
  Clear = 4,
  Snow = 5,
  Wind = 6,
  Drizzle=7,
  Mist=8
}

export class WeatherForecastModel {
  cityName: string;
  date: Date;
  temperatureCDay: number;
  temperatureFDay: number;
  temperatureCNight: number;
  temperatureFNight: number;
  precipitation: number;
  humidity: number;
  wind: number;
  weatherStatus: WeatherStatus;
  dayCycle: DayCycle;
  summary: string;
}
