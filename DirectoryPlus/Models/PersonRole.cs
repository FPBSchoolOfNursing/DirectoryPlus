using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Models
{
    public class PersonRole
    {
        public string CaseUserID { get; set; }
        public string Role { get; set; }
        public virtual Person Person { get; set; }
    }
}