using DirectoryPlus.Interfaces;
using CasAuthenticationMiddleware.Attributes;
using DirectoryPlus.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectoryPlus.Services
{
    public class ActiveDirectoryService
    {
        private IDirectoryContext db;

        public ActiveDirectoryService(IDirectoryContext context)
        {
            db = context;
        }

        public async Task SyncLocalDbAsync(string ADDomain, string ADGroup)
        {           
          
            var userids = ActiveDirectory.UsersInGroup(ADDomain, ADGroup); //query active directory for the people in AdGroup


            foreach(string uid in userids)
            {               
                if (CaseUserIDRegex.isMatch(uid)) //if it is a case id (non case ids could be returned such as ads servicing accounts
                {
                    var updateme = db.People.Find(uid);
                    if (updateme != null)
                    {
                        var dbservice = new DirectoryService(db);
                        dbservice.AddDirectoryEntry(null);
                        
                        //update a new person 
                    }
                    else
                    {
                        //query ldap for the attributes 

                        var ldapTask = await LDAP.GetPoo(PooQueriables.CaseID, "bdm4");
                        int i = 0;

                        //insert them into our db.
                                                
                        //insert a new person into the database. 
                    }
                }
            }
           
            //update the records for those people. 
            
        }
    }
}