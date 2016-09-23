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
        private IDirectoryContext _context;

        public ActiveDirectoryService(IDirectoryContext context)
        {
            _context = context;
        }

        public bool SyncLocalDb(string ADDomain, string ADGroup)
        {
            bool inSync = false;
            ActiveDirectory.UsersInGroup(ADDomain, ADGroup);     
            //query active directory for the people in AdGroup
            //update the records for those people. 
            return inSync;
        }
    }
}