using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class BiasedGenerator:IRandomGenerator
    {
        Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double GenerateValue(double lowerLimit, double upperLimit)
        {
            if(generator.Next(1,4)<3)
                return (generator.NextDouble() * (upperLimit - lowerLimit))/2 + lowerLimit;
            else
                return generator.NextDouble() * (upperLimit - lowerLimit) + lowerLimit;
        }
    }
}
