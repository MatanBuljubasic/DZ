using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class WeeklyForecast
    {
        private DailyForecast[] days= new DailyForecast[7];

        public WeeklyForecast(DailyForecast[] forecasts)
        {
            for(int i=0; i < forecasts.Length; i++)
            {
                days[i] = forecasts[i];
            }
        }

        public string GetAsString()
        {
            string forecast = "";
            for(int i=0; i<days.Length; i++)
            {
                forecast += $"{days[i].GetAsString()}\n";
            }
            return forecast;
        }

        public string GetMaxTemperature()
        {
            DailyForecast max = days[0];
            for(int i = 1; i < days.Length; i++)
            {
                if(days[i] > max)
                {
                    max = days[i];
                }
            }
            return max.Weather.GetTemperature().ToString(new System.Globalization.CultureInfo("en-us", false));
        }

        public DailyForecast this[int dayIndex]
        {
            get { return days[dayIndex]; }
        }
    }
}
