using System;
using System.IO;
using Class_Library;

namespace Program_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime monday = new DateTime(2021, 11, 8); 
            Weather mondayWeather = new Weather(6.17, 56.13, 4.9); 
            DailyForecast mondayForecast = new DailyForecast(monday, mondayWeather); 
            Console.WriteLine(monday.ToString()); //Ne postoji način, bar kolko sam ja uspio skužiti, da ovaj ispis bude u formatu dd/MM/yyyy hh:mm:ss
            Console.WriteLine(mondayWeather.GetAsString());
            Console.WriteLine(mondayForecast.GetAsString());
            string fileName = "weather.forecast"; //Treba .txt na kraju?    
            if (File.Exists(fileName) == false)    
            {        
                Console.WriteLine("The required file does not exist. Please create it, or change the path.");        
                return;    
            }    
            string[] dailyWeatherInputs = File.ReadAllLines(fileName);    
            DailyForecast[] dailyForecasts = new DailyForecast[dailyWeatherInputs.Length];    
            for (int i = 0; i < dailyForecasts.Length; i++)    
            {        
                dailyForecasts[i] = ForecastUtilities.Parse(dailyWeatherInputs[i]);    
            }    
            WeeklyForecast weeklyForecast = new WeeklyForecast(dailyForecasts);    
            Console.WriteLine(weeklyForecast.GetAsString());    
            Console.WriteLine("Maximal weekly temperature:");    
            Console.WriteLine(weeklyForecast.GetMaxTemperature());    
            Console.WriteLine(weeklyForecast[0].GetAsString());
        }
    }
}
