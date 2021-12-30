using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class NoSuchDailyWeatherException :System.Exception
    {
        private DateTime date;

        public NoSuchDailyWeatherException() { }
        public NoSuchDailyWeatherException(string message, DateTime date) : base(message)
        {
            this.date = date;
        }
    }
}
