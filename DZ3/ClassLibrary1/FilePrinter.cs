using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    public class FilePrinter:IPrinter
    {
        string adress;

        public FilePrinter(string adress)
        {
            this.adress = adress;
        }

        public void Print(Weather[] weathers)
        {
            using (StreamWriter writer = new StreamWriter(adress))
            {
                foreach (Weather weather in weathers)
                {
                    writer.WriteLine(weather.ToString());
                }
            }
        }
    }
}
