using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class ForecastUtilities
    {
        static public Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            int maxIndex = 0;
            for (int i = 1; i < weathers.Length; i++)
            {
                if (weathers[i].CalculateWindChill() > weathers[maxIndex].CalculateWindChill()) maxIndex = i;
            }
            return weathers[maxIndex];
        }

        static public DailyForecast Parse(string input)
        {
            string[] inputs=input.Split(",");
            Weather weather = new Weather(double.Parse(inputs[1], System.Globalization.CultureInfo.InvariantCulture), double.Parse(inputs[3], System.Globalization.CultureInfo.InvariantCulture), double.Parse(inputs[2], System.Globalization.CultureInfo.InvariantCulture));
            return new DailyForecast(Convert.ToDateTime(inputs[0]), weather);
        }
    }
}
