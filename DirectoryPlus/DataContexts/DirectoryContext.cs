using System;
using System.Data.Entity;
using DirectoryPlus.Interfaces;
using DirectoryPlus.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DirectoryPlus.DataContexts
{
    public class DirectoryContext : DbContext, IDirectoryContext
    {
        public DirectoryContext() : base("DirectoryContext") { }

        public DbSet<Office> Offices { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonRole> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}