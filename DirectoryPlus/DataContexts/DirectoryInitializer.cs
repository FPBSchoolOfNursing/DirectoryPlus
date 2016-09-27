using System.Data.Entity;
using DirectoryPlus.Models;
using System.Collections.Generic;
using System;

namespace DirectoryPlus.DataContexts
{
    public class DirectoryInitializer: DropCreateDatabaseIfModelChanges<DirectoryContext>
    {
        protected override void Seed(DirectoryContext context)
        {
            var people = new List<Person>
            {
                new Person { CaseUserId = "abc123", FirstName = "Alice", LastName="Contera", LastModified=DateTime.Now, PhoneNumber="216-368-0000" },
                new Person { CaseUserId = "abc124", FirstName = "Alice2", LastName="Contera2", LastModified=DateTime.Now, PhoneNumber="216-368-2000"},
                new Person { CaseUserId = "abc1250", FirstName = "Alice3", LastName="Contera3", LastModified=DateTime.Now, PhoneNumber="216-368-3000" }
            };

            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();

            var office = new List<Office> {
                new Office { Building = "Nursing", RoomNumber="219G" },
                new Office { Building = "Wood", RoomNumber="215" },
                new Office { Building = "Nursing", RoomNumber="1115" },
                new Office { Building = "MiddleEarth", RoomNumber="NOB150" },
            };

            office.ForEach(o => context.Offices.Add(o));
            context.SaveChanges();

            var groups = new List<Group>
            {
                new Group { GroupName = "nurs-dept-it", Description="Nursing IT", Email="fpbhelpdesk@case.edu" },
                new Group { GroupName = "utech", Description="uTech peeps", Email="utech@case.edu" },
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();
        }
    }
}