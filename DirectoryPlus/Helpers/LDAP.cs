using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DirectoryPlus.Helpers
{
    public class LDAP
    {
        static HttpClient client = new HttpClient();        

        public static async Task<CaseLDAPReturn> GetPoo(PooQueriables QueryBy, string SearchTerm)
        {
            CaseLDAPReturn pooresults = null;
            string baseuri = "https://bell47.case.edu/services/poo/getpoo/caseid/bdm4";

            HttpResponseMessage response = await client.GetAsync(baseuri);
            if (response.IsSuccessStatusCode)
            {
                pooresults = await response.Content.ReadAsAsync<CaseLDAPReturn>();
            }
            return pooresults;
        }       
    }

    public sealed class PooQueriables
    {

        private readonly String name;
        private readonly int value;

        public static readonly PooQueriables CaseID = new PooQueriables(1, "caseid");
        public static readonly PooQueriables LastName = new PooQueriables(2, "lastname");
        public static readonly PooQueriables WholeName = new PooQueriables(3, "wholename");
        public static readonly PooQueriables Phone = new PooQueriables(4, "phone");
        public static readonly PooQueriables LdapQuery = new PooQueriables(5, "raw");
        public static readonly PooQueriables AdsGroup = new PooQueriables(6, "adsgroup");

        private PooQueriables(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }

    }

    public class CaseLDAPReturn
    {
        public CaseLDAPReturn()
        {
            SearchResults = new List<CaseLDAPSearchResults>();
        }
        public int ResultsCount
        {
            get; set;
        }

        public string SearchTime
        {
            get; set;
        }

        public List<CaseLDAPSearchResults> SearchResults
        {
            get; set;
        }
    }
    /// <summary>
    /// This class gets serialized from LDAP Searchresults.
    /// </summary>
    public class CaseLDAPSearchResults
    {
        public CaseLDAPSearchResults()
        {
            objectclass = new List<string>();
            mailequivalentaddress = new List<string>();
            otherstuff = new List<KeyValuePair<string, string>>();
        }
        public List<string> objectclass { get; set; }
        public List<string> mailequivalentaddress { get; set; }
        public List<KeyValuePair<string, string>> otherstuff { get; set; }
        public string mail { get; set; }
        public string sn { get; set; }
        public string telephonenumber { get; set; }
        public string cn { get; set; }
        public string ou { get; set; }
        public string mailalternateaddress { get; set; }
        public string physicaldeliveryofficename { get; set; }
        public string displayname { get; set; }
        public string title { get; set; }
        public string street { get; set; }
        public string adspath { get; set; }
        public string o { get; set; }
        public string departmentnumber { get; set; }
        public string uid { get; set; }
        public string givenname { get; set; }
        public string initials { get; set; }
        public string postaladdress { get; set; }

    }
}