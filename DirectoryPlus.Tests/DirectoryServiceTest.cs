using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DirectoryPlus.Tests.TestContext;
using DirectoryPlus.Services;
using System.Linq;

namespace DirectoryPlus.Tests
{
    [TestClass]
    public class DirectoryServiceTest
    {
        [TestMethod]
        public void Create_Directory_Entry()
        {
            var context = new DirectoryTestContext();
            var service = new DirectoryService(context);
            var fakeperson = DbFakes.GetFakePeople().First();
            service.AddDirectoryEntry(fakeperson);

            Assert.AreEqual(1, context.People.Count());
            Assert.AreEqual("Alice", context.People.First().FirstName);
            Assert.AreEqual("Crushe", context.People.First().LastName);
            Assert.AreEqual(1, context.SaveChangesCount);
        }
    }
}
