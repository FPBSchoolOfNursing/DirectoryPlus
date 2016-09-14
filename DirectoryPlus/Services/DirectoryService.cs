using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DirectoryPlus.Interfaces;
using DirectoryPlus.Models;


namespace DirectoryPlus.Services
{
    public class DirectoryService
    {
        private IDirectoryContext _context;

        public DirectoryService(IDirectoryContext context)
        {
            _context = context;
        }

        public void AddDirectoryEntry(Person person)
        {           
            _context.People.Add(person);
            _context.SaveChanges();
        }
    }
}