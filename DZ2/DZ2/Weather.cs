using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Weather
    {
        private double temperature;
        private double humidity;
        private double windSpeed;

        public Weather() 
        {
            temperature = 20;
            humidity = 5;
            windSpeed = 5;
        }

        public Weather(double temperature, double humidity, double windSpeed) { this.temperature = temperature; this.humidity = humidity; this.windSpeed = windSpeed; }

        public void SetTemperature(double temperature) { this.temperature = temperature; }

        public void SetHumidity(double humidity) { this.humidity = humidity; }

        public void SetWindSpeed(double windSpeed) { this.windSpeed = windSpeed; }

        public double GetTemperature() { return temperature; }

        public double GetHumidity() { return humidity; }

        public double GetWindSpeed() { return windSpeed; }

        public double CalculateFeelsLikeTemperature()
        {
            Constants constants = new Constants();
            return constants.GetC1() + constants.GetC2() * temperature + constants.GetC3() * humidity + constants.GetC4() * temperature * humidity + constants.GetC5() * temperature * temperature + constants.GetC6() * humidity * humidity + constants.GetC7() * temperature * temperature * humidity + constants.GetC8() * temperature * humidity * humidity + constants.GetC9() * temperature * temperature * humidity * humidity;
        }

        public double CalculateWindChill()
        {
            if (GetTemperature() <= 10 && GetWindSpeed() > 4.8) return 13.12 + 0.6215 * GetTemperature() - 11.37 * Math.Pow(GetWindSpeed(), 0.16) + 0.3965 * GetTemperature() * Math.Pow(GetWindSpeed(), 0.16);
            else return 0;
        }

        public Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            int maxIndex = 0;
            for (int i = 1; i < weathers.Length; i++)
            {
                if (weathers[i].CalculateWindChill() > weathers[maxIndex].CalculateWindChill()) maxIndex = i;
            }
            return weathers[maxIndex];
        }

        public string GetAsString()
        {
            
            return $"T={temperature.ToString(new System.Globalization.CultureInfo("en-us", false))}°C, w={windSpeed.ToString(new System.Globalization.CultureInfo("en-us", false))}km/h, h={humidity.ToString(new System.Globalization.CultureInfo("en-us", false))}%";
        }
    }
}