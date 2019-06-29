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
    public class Test6_ModifyContact : AuthTestBase
    {
        [Test]
        public void ModifyContactTest()
        {
            Class3_ContactData data = new Class3_ContactData("Croopper", null);
            data.Firstname = "Croopper";
            data.Lastname = null;
            data.MobilePhone = null;
            List<Class3_ContactData> oldContact = Class3_ContactData.GetAllContactInfo();
            app.Contacts.ModifyContact(oldContact[0], data);
            List<Class3_ContactData> newContact = Class3_ContactData.GetAllContactInfo();
            oldContact[0].Firstname = data.Firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}