using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CaseUserID { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string HomePageURL { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public DateTime LastModified { get; set; }
        public virtual List<Office> Offices { get; set; }
     }

    public class Office
    {
        public int Number { get; set; }
        public string Building { get; set; }
        public string PhoneNumber { get; set; }
        public float SquareFeet { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Elevation { get; set; }
    }
}