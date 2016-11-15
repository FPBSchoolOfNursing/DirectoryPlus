using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DirectoryPlus.Helpers
{
    public static class CaseUserIDRegex
    {
        public static bool isMatch(string CaseID)
        {
            Regex caseid = new Regex(@"^[a-zA-Z]{3}([1-9]\d{0,3})?$");
            return caseid.IsMatch(CaseID);           
        }
    }
}