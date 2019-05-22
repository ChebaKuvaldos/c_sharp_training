using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class AddContact : TestBase
    {
        [Test]
        public void TheAddContactTest()
        {
            app.Navigator.InitAddContact();
            Class3_ContactData contact = new Class3_ContactData();
            contact.Firstname = "Petya";
            contact.Lastname = "Dude";
            contact.Mobile = "+791111111";
            app.Contacts.FillContactData(contact)
                        .AddContactSubmit();
            app.Navigator.HomePage()
                         .Logout();
        }
    }
}
