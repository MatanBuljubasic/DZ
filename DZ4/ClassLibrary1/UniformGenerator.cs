using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class UniformGenerator : IRandomGenerator
    {
        Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }
        public double GenerateValue(double lowerLimit, double upperLimit)
        {
            return generator.NextDouble() * (upperLimit - lowerLimit) + lowerLimit;
        }
    }
}
