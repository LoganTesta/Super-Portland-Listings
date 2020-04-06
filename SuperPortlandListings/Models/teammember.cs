using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPortlandListings.Models
{
    public class teammember
    {
        public string name { get; set; }
        public string classCSS { get; set; }
        public string title { get; set; }
        public string photoFileName{ get; set; }
        public string description { get; set; }

        public teammember(string name, string classCSS, string title, string photoFileName, string description)
        {
            this.name = name;
            this.classCSS = classCSS;
            this.title = title;
            this.photoFileName = photoFileName;
            this.description = description;
        }
    }
}
