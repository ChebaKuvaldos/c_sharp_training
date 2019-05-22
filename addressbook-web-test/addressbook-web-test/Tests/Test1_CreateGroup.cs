using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void CreateGroup()
        {
            Class2_GroupData group = new Class2_GroupData("Group11");
            group.Header = "Root";
            group.Footer = "Good";

            app.Groups.Create(group);

            app.Navigator.Logout();
        }
        [Test]
        public void CreateEmptyGroup()
        {

            Class2_GroupData group = new Class2_GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);

            app.Navigator.Logout();
        }
    }
}
