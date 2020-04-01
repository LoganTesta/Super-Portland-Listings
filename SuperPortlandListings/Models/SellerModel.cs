using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPortlandListings.Models
{
    public class SellerModel
    {
        public string sellerName { get; set; }
        public string sellerEmail { get; set; }
        public string sellerPhone { get; set; }
        public string sellerCity { get; set; }
        public string sellerState { get; set; }
        public string sellerZIP { get; set; }
        public string sellerShortDescription { get; set; }
        public string sellerDesiredPrice { get; set; }
        public string sellerDesiredSellDate { get; set; }
        public string sellerAdditionalNotes { get; set; }      
    }
}
