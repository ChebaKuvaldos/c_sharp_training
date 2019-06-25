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
        public static IEnumerable<Class3_ContactData> RandomContactDataProvider()
        {
            List<Class3_ContactData> groups = new List<Class3_ContactData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new Class3_ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(150),
                    MobilePhone = GenerateRandomString(10),
                    HomePhone = GenerateRandomString(10),
                    WorkPhone = GenerateRandomString(10),
                });
            }
            return groups;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void TheAddContactTest(Class3_ContactData contact)
        {
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
