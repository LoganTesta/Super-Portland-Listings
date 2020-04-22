using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SuperPortlandListings.Models;
namespace SuperPortlandListings
{
    public class Program
    {

        public static listing listing0 = new listing("Cheery Neighborhood House", "zero", "Hillsboro", "Washington", "22110 SW Hillsboro 97123", "$550,000", "January 15, 2020", "2005", "2200", "4800", 
            "3", "2", "3", "2", "/assets/images/house0.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing1 = new listing("Perfect for Families", "one", "Hillsboro", "Washington", "22111 SW Hillsboro 97123", "$540,000", "January 6, 2020", "2005", "2800", "4500", 
            "4", "3", "3", "2", "/assets/images/house1.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing2 = new listing("One Story Southwestern Style Home", "two", "Hillsboro", "Washington", "22112 SW Hillsboro 97123", "$439,000", "January 27, 2020", "2005", "1850", "5400", 
            "3", "2", "2", "1", "/assets/images/house2.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing3 = new listing("Big Front Yard with this Home", "three", "Hillsboro", "Washington", "22113 SW Hillsboro 97123", "$780,000", "January 12, 2020", "2005", "2500", "8000", 
            "7", "4", "4", "2", "/assets/images/house3.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");

        public static listing listing4 = new listing("Perfect for Growing Families", "four", "Forest Grove", "Washington", "22111 SW Forest Grove 97116", "$541,000", "January 19, 2020", "2005", "2900", "7200", 
            "6", "4", "2", "2", "/assets/images/house4.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing5 = new listing("Charming Neighborhood Home", "five", "Forest Grove", "Washington", "22112 SW Forest Grove 97116", "$495,000", "January 11, 2020", "2005", "1950", "5000", 
            "3", "2", "2", "2", "/assets/images/house5.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");

        public static listing listing6 = new listing("New House, Refined Look", "six", "Cornelius", "Washington", "22110 SW Cornelius 97113", "$449,000", "January 4, 2020", "2005", "2000", "6000", 
            "4", "2", "2", "2", "/assets/images/house6.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing7 = new listing("Large Front and Back Yard", "seven", "Cornelius", "Washington", "22111 SW Cornelius 97113", "$491,000", "January 25, 2020", "2005", "2800", "7000", 
            "6", "3", "2", "2", "/assets/images/house7.jpeg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");


        public static listing listing8 = new listing("Beautiful Front Porch and Yard", "eight", "Forest Grove", "Washington", "22113 SW Forest Grove 97116", "$475,000", "January 28, 2020", "1980", "2800", "6000", 
            "6", "3", "2", "2", "/assets/images/house8.jpg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing9 = new listing("New Home with Plenty Nearby", "nine", "Hillsboro", "Washington", "22114 SW Hillsboro 97123", "$475,000", "January 14, 2020", "2005", "2100", "7400", 
            "4", "3", "2", "2", "/assets/images/house9.jpg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing10 = new listing("Pleasant Home in Quiet Neighborhood", "ten", "Forest Grove", "Washington", "22114 SW Forest Grove 97116", "$290,000", "January 16, 2020", "1940", "1400", "6000", 
            "3", "1", "1", "1", "/assets/images/house10.jpg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");
        public static listing listing11 = new listing("Well Maintained Home for Sale", "eleven", "Aloha", "Washington", "22110 SW Aloha 97006", "$440,000", "January 27, 2020", "2006", "2100", "6000", 
            "4", "3", "2", "2", "/assets/images/house11.jpg", "This house is great.", "This house is great. You should visit it and buy it if you like it.");

        public static List<listing> theListings = new List<listing>();
        public static string projectDateString = "January 30, 2020";
        public static DateTime projectDate = Convert.ToDateTime(projectDateString);

        public static void Main(string[] args)
        {
            theListings.Add(listing0);
            theListings.Add(listing1);
            theListings.Add(listing2);
            theListings.Add(listing3);
            theListings.Add(listing4);
            theListings.Add(listing5);
            theListings.Add(listing6);
            theListings.Add(listing7);
            theListings.Add(listing8);
            theListings.Add(listing9);
            theListings.Add(listing10);
            theListings.Add(listing11);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
