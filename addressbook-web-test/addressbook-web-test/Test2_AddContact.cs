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
            HomePage();
            Login(new Class1_AccountData("admin", "secret"));
            InitAddContact();
            Class3_ContactData contact = new Class3_ContactData();
            contact.Firstname = "Petya";
            contact.Lastname = "Dude";
            contact.Mobile = "+791111111";
            FillContactData(contact);
            AddContactSubmit();
            HomePage();
            Logout();
        }
    }
}
