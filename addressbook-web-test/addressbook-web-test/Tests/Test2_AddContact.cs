using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class AddContact : AuthTestBase
    {
        [Test]
        public void TheAddContactTest()
        {
            Class3_ContactData contact = new Class3_ContactData("kumis","kronsteine");
            contact.Mobile = "+791111111";
            app.Navigator.HomePage();

            List<Class3_ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.CreateContact(contact);
            List<Class3_ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }
        }
}
