using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Models
{
    public class Office
    {
        public int Number { get; set; }
        public string Building { get; set; }
        public string PhoneNumber { get; set; }
        public float SquareFeet { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Elevation { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}