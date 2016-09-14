using DirectoryPlus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryPlus.Interfaces
{
    public interface IDirectoryContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Office> Offices { get; set; }
    }
}
