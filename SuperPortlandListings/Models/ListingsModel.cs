using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperPortlandListings.Models
{
    public class ListingsModel
    {
        [BindProperty]
        public string searchCity { get; set; }
        [BindProperty]
        public string searchByOptions { get; set; }
    }
}
