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
            List<Class3_ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.RemoveContact(0);
            List<Class3_ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
