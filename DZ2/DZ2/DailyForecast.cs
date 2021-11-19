using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Class_Library
{
    public class DailyForecast
    {
        private DateTime date;
        private Weather weather;

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather = weather;
        }

        public string GetAsString()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            return $"{date.ToString("G", culture)}: {weather.GetAsString()}";
        }

        public Weather Weather
        {
            get { return weather; }
        }

        public static bool operator >(DailyForecast forecast1, DailyForecast forecast2)
        {
            if (forecast1.Weather.GetTemperature() > forecast2.Weather.GetTemperature())
            {
                return true;
            }
            else return false;
        }

        public static bool operator <(DailyForecast forecast1, DailyForecast forecast2)
        {
            if (forecast1.Weather.GetTemperature() < forecast2.Weather.GetTemperature())
            {
                return true;
            }
            else return false;
        }
    }
}
