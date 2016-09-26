using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}