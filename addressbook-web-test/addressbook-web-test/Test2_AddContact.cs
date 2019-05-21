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
            navigator.HomePage();
            loginHelper.Login(new Class1_AccountData("admin", "secret"));
            navigator.InitAddContact();
            Class3_ContactData contact = new Class3_ContactData();
            contact.Firstname = "Petya";
            contact.Lastname = "Dude";
            contact.Mobile = "+791111111";
            contactHelper.FillContactData(contact);
            contactHelper.AddContactSubmit();
            navigator.HomePage();
            navigator.Logout();
        }
    }
}
