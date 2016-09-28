using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Models
{
    public class PersonRole
    {
        [Key]
        public string CaseUserId { get; set; }
        public string Role { get; set; }
        public virtual Person Person { get; set; }
    }
}