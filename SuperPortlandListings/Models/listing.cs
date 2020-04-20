using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPortlandListings.Models
{
    public class listing
    {
        public string name { get; set; }
        public string classCSS { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string address { get; set; }
        public string price { get; set; }
        public string placedOnMarket { get; set; }
        public string yearBuilt { get; set; }
        public string homeSquareFootage { get; set; }
        public string lotSquareFootage { get; set; }
        public string numberOfBedrooms { get; set; }
        public string numberOfBathrooms { get; set; }
        public string parkingSpaces { get; set; }
        public string numberOfStories { get; set; }
        public string photoFilePath { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }

        public listing(string name, string classCSS, string city, string county, string address, string price, string placedOnMarket, string yearBuilt, string homeSquareFootage, string lotSquareFootage, 
            string numberOfBedrooms, string numberOfBathrooms, string parkingSpaces, string numberOfStories, string photoFilePath, string shortDescription, string description)
        {
            this.name = name;
            this.classCSS = classCSS;
            this.city = city;
            this.county = county;
            this.address = address;
            this.price = price;
            this.placedOnMarket = placedOnMarket;
            this.yearBuilt = yearBuilt;
            this.homeSquareFootage = homeSquareFootage;
            this.lotSquareFootage = lotSquareFootage;
            this.numberOfBedrooms = numberOfBedrooms;
            this.numberOfBathrooms = numberOfBathrooms;
            this.numberOfStories = numberOfStories;
            this.parkingSpaces = parkingSpaces;
            this.photoFilePath = photoFilePath;
            this.shortDescription = shortDescription;
            this.description = description;
        }

        public listing()
        {

        }

    }
}
