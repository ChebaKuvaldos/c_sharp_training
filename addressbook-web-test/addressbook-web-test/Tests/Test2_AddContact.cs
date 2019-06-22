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
            Class3_ContactData contact = new Class3_ContactData("Negodyai","Vanya");
            contact.Address = "St.Paulostan,CocoStr,543";
            contact.MobilePhone = "+791111111";
            contact.HomePhone = "11";
            contact.WorkPhone = "+3333333";
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
