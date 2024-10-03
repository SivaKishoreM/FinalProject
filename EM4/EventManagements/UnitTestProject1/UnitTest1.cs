using EventManagements.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;
using EventManagements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            using (var context = new EventManagementSystemEntities())
            {
                var admin = new user
                {
                    Username = "k",
                    Fullname = "kiran",
                    Role = "User",
                    password = "765",
                };

                // Act
                context.users.Add(admin);
                context.SaveChanges();  // This commits the changes to the database

                // Assert - Check if the data was inserted
                var insertedAdmin = context.users.SingleOrDefault(a => a.Username == "k");  // Query the database to find the admin by AdminId
                Assert.IsNotNull(insertedAdmin);  // Check that the admin was successfully inserted
                Assert.AreEqual("k", insertedAdmin.Username);  // Validate that the correct data was inserted
                Assert.AreEqual("User", insertedAdmin.Role);  // Validate the phone number
                Assert.AreEqual("765", insertedAdmin.password);  // Validate the email
            }

        }
    }
}
