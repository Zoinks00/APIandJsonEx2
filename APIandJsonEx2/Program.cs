using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace APIandJsonEx2
{
    class Program
    {
        

        static void Main(string[] args)
        /*
         website used 
         https://openweathermap.org/current#data
         */


        {//create new instance of HttpClient 
            var client = new HttpClient();
            //prompt user to add their API key for weathersite
            Console.WriteLine("Enter your API key now to access OpenWeatherMap URL:");
            //store user input in variable apiKey
            var apiKey = Console.ReadLine();
         
            Console.WriteLine("\nWould you like to search a city's weather?");

            string userInput = Console.ReadLine();
            // while loop will works while userInput = y or yes
            while (userInput.ToLower() == "yes" || userInput =="y")
            {
                Console.WriteLine("\nEnter the city name you wish to see current weather for:");
                //stores user input for city name
                var cityName = Console.ReadLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

                var response = client.GetStringAsync(weatherURL).Result;
                // format response from weatherURL to make more readable
                var formatResponse = JObject.Parse(response).GetValue("main").ToString();
                
                Console.WriteLine("Current temp");
                Console.WriteLine(formatResponse);

                Console.WriteLine("Current Wind");
                 formatResponse = JObject.Parse(response).GetValue("wind").ToString();
                Console.WriteLine(formatResponse);

                Console.WriteLine("\nWould you like to search a new city?");

                userInput = Console.ReadLine();

            }
        }
    }
}
