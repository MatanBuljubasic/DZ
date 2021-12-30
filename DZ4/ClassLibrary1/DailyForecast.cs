using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClassLibrary1
{
    public class DailyForecast : IComparable<DailyForecast>
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
            return $"{date.ToString("G", culture)}: {weather}";
        }

        public int CompareTo(DailyForecast forecast)
        {
            if (date < forecast.date) return -1;
            else if (date > forecast.date) return 1;
            else return 0;
        }

        public DateTime Date
        {
            get { return date; }
        }

        public Weather Weather
        {
            get { return weather; }
        }
    }
}
