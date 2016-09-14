using System;
using System.Data.Entity;
using DirectoryPlus.Interfaces;
using DirectoryPlus.Models;

namespace DirectoryPlus.DataContexts
{
    public class DirectoryContext : DbContext, IDirectoryContext
    {
        public DirectoryContext() : base("name=DirectoryContext") { }

        public DbSet<Office> Offices { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            base.OnModelCreating(modelBuilder);
        }
    }
}