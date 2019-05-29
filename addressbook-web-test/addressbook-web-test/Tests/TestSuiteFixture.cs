using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_test
{
    [SetUpFixture]
    public class TestSuiteFixture
    {

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstanse();
            app.Navigator.HomePage();
            app.Auth.Login(new Class1_AccountData("admin", "secret"));
        }

    }
}
