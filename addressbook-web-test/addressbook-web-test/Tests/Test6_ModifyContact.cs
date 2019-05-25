using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test6_ModifyContact : TestBase
    {
        [Test]
        public void ModifyContactTest()
        {
            Class3_ContactData contact = new Class3_ContactData();
            contact.Firstname = "Croopper";
            contact.Lastname = null;
            contact.Mobile = null;
            app.Contacts.EditContact()
                        .FillContactData(contact)
                        .UpdateContact();
            app.Navigator.Logout();
        }
    }
}