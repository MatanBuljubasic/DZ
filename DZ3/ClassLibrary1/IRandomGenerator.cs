using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public interface IRandomGenerator
    {
        public double GenerateValue(double lowerLimit, double upperLimit);
    }
}
