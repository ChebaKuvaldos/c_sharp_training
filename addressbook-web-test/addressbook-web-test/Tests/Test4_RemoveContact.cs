using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test4_RemoveContact : TestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.SelectContact(1)
                      .DeleteSelectedContact();
            app.Driver.SwitchTo().Alert().Accept();
            app.Navigator.Logout();
        }
    }
}
