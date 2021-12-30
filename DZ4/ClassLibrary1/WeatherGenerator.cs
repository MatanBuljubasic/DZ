using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class WeatherGenerator
    {
        double minTemperature;
        double maxTemperature;
        double minHumidity;
        double maxHumidity;
        double minWindSpeed;
        double maxWindSpeed;
        IRandomGenerator randomGenerator;

        public WeatherGenerator(double minTemperature, double maxTemperature, double minHumidity, double maxHumidity, double minWindSpeed, double maxWindSpeed, IRandomGenerator randomGenerator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.randomGenerator = randomGenerator;
        }

        public Weather Generate()
        {
            Weather weather = new Weather(randomGenerator.GenerateValue(minTemperature, maxTemperature), randomGenerator.GenerateValue(minHumidity, maxHumidity), randomGenerator.GenerateValue(minWindSpeed, maxWindSpeed));
            return weather;
        }

        public void SetGenerator(IRandomGenerator generator)
        {
            randomGenerator = generator;
        }
    }
}
