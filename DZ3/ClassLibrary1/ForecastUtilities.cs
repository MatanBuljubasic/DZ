using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ForecastUtilities
    {
        public static void PrintWeathers(IPrinter[] printers, Weather[] weathers)
        {
            foreach (IPrinter printer in printers)
            {
                
                 printer.Print(weathers);
                
            }
        }
    }
}
