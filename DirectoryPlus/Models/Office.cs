﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Models
{
    public class Office
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficeId { get; set; }
        public string CaseUserId { get; set; }
        public string RoomNumber { get; set; }
        public string Building { get; set; }
        public string PhoneNumber { get; set; }
        public float SquareFeet { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Elevation { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}