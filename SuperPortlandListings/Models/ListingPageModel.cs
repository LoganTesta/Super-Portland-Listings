using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPortlandListings.Models
{
    public class ListingPageModel
    {
        public decimal houseCost { get; set; } 
        public decimal downPayment { get; set; }
        public int mortgageDuration { get; set; }
        public decimal interestRate { get; set; }
    }
}
