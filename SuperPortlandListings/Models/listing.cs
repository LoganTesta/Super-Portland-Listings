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
        public string address { get; set; }
        public string price { get; set; }
        public string placedOnMarket { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }

        public listing(string name, string classCSS, string city, string address, string price, string placedOnMarket, string shortDescription, string description)
        {
            this.name = name;
            this.classCSS = classCSS;
            this.city = city;
            this.address = address;
            this.price = price;
            this.placedOnMarket = placedOnMarket;
            this.shortDescription = shortDescription;
            this.description = description;
        }
    }
}
