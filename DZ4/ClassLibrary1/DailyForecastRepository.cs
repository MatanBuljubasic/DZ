using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 
{
    public class DailyForecastRepository : IEnumerable<DailyForecast>
    {

        private List<DailyForecast> forecasts;

        public DailyForecastRepository()
        {
            this.forecasts = new List<DailyForecast>();
        }

        public DailyForecastRepository(DailyForecastRepository repository) : this()
        {
            foreach(DailyForecast forecast in repository.forecasts)
            {
                DailyForecast copy = new DailyForecast(forecast.Date, forecast.Weather);
                this.forecasts.Add(copy);
            }
        }

        public void Add(DailyForecast forecast)
        {
            foreach(DailyForecast forecast1 in forecasts)
            {
                if(forecast1.Date.Day == forecast.Date.Day)
                {
                    forecasts.Remove(forecast1);
                    break;
                }
            }
            forecasts.Add(forecast);
            forecasts.Sort();
        }

        public void Add(List<DailyForecast> forecasts)
        {
            foreach (DailyForecast forecast1 in forecasts)
            {
                foreach(DailyForecast forecast2 in this.forecasts)
                {
                    if (forecast1.Date.Day == forecast2.Date.Day)
                    {
                        this.forecasts.Remove(forecast2);
                        break;
                    }
                }
                
            }
            this.forecasts.AddRange(forecasts);
            forecasts.Sort();
        }

        public IEnumerator<DailyForecast> GetEnumerator()
        {
            return ((IEnumerable<DailyForecast>)forecasts).GetEnumerator();
        }

        public void Remove(DateTime date)
        {
            int removableForecasts = 0;
            int removableForecastIndex = 0;
            for(int i = 0; i < forecasts.Count; i++)
            {
                if (forecasts[i].Date.Day == date.Day && forecasts[i].Date.Month == date.Month && forecasts[i].Date.Year == date.Year)
                {
                    removableForecasts++;
                    removableForecastIndex = i;
                }
            }
            if (removableForecasts == 0)
                throw new NoSuchDailyWeatherException($"Cannot remove forecast with date {date}, no such date", date);
            forecasts.RemoveAt(removableForecastIndex);
        }

        public override string ToString()
        {
            string forecast=string.Empty;
            foreach(DailyForecast forecast1 in forecasts)
            {
                forecast += $"{forecast1.Date}: T={forecast1.Weather.GetTemperature()}°C, w={forecast1.Weather.GetWindSpeed()}km/h, h={forecast1.Weather.GetHumidity()}%\n";
            }
            forecast = forecast.Remove(forecast.Length - 2);
            return forecast;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)forecasts).GetEnumerator();
        }
    }
}
