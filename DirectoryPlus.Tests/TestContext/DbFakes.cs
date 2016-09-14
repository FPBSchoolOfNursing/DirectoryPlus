using DirectoryPlus.Models;
using System;
using System.Collections.Generic;

namespace DirectoryPlus.Tests.TestContext
{
    public static class DbFakes
    {
        public static List<Person> GetFakePeople()
        {
            return new List<Person>
            {
                new Person
                {
                     CaseUserID = "abc123",
                      FirstName = "Alice",
                       LastName = "Crushe",
                        Title="SysOp",
                          PhoneNumber="216-555-6666",
                           Prefix="Mrs.",
                             Suffix="PhD",
                               HomePageURL="https://case.edu",
                                ImageURL="https://images.case.edu",
                                 LastModified = new DateTime (2000, 1,1)
                }
            };
        }
    }
}
