using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test4_RemoveContact : AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.ContactExist();
            List<Class3_ContactData> oldContact = Class3_ContactData.GetAllContactInfo();
            Class3_ContactData toBeRemoved = oldContact[0];

            app.Contacts.RemoveContactDB(toBeRemoved);
            List<Class3_ContactData> newContact = Class3_ContactData.GetAllContactInfo();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
