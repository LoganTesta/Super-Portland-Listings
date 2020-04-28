using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperPortlandListings.Models
{
    public class ListingsModel
    {
        public string searchCity { get; set; }
        public string searchByOptions { get; set; }
    }
}
