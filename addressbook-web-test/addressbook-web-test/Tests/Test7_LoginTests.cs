using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test7_LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            Class1_AccountData account = new Class1_AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));
  
        }
        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.Logout();

            Class1_AccountData account = new Class1_AccountData("admin", "12345");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }
    }
}
