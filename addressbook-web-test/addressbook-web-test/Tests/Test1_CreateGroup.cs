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
            app.Navigator.HomePage();
            app.Auth.Login(new Class1_AccountData ("admin","secret"));
            app.Navigator.GroupsPage();
            app.Groups.InitNewGroupCreation();
            Class2_GroupData group = new Class2_GroupData("Group11");
            group.Header = "Root";
            group.Footer = "Good";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.GroupsPage();
            app.Navigator.Logout();
        }
    }
}
