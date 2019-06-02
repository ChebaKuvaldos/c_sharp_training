using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class AddContact : AuthTestBase
    {
        [Test]
        public void TheAddContactTest()
        {
            app.Navigator.HomePage();
            app.Contacts.CreateContact();
            app.Auth.Logout();
        }
    }
}
