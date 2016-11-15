using DirectoryPlus.Interfaces;
using CasAuthenticationMiddleware.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryPlus.Services
{
    public class ActiveDirectoryService
    {
        private IDirectoryContext db;

        public ActiveDirectoryService(IDirectoryContext context)
        {
            db = context;
        }

        public bool SyncLocalDb(string ADDomain, string ADGroup)
        {
            bool inSync = false;
          
            var userids = ActiveDirectory.UsersInGroup(ADDomain, ADGroup); //query active directory for the people in AdGroup

            foreach(var uid in userids)
            {
                var updateme = db.People.Find(uid);
                if(updateme != null)
                {
                    //update a new person 
                }
                else
                {                    
                    //insert a new person into the database. 
                }
            }
           
            //update the records for those people. 
            return inSync;
        }
    }
}