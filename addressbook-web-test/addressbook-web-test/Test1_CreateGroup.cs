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
            navigator.HomePage();
            loginHelper.Login(new Class1_AccountData ("admin","secret"));
            navigator.GroupsPage();
            GroupHelper.InitNewGroupCreation();
            Class2_GroupData group = new Class2_GroupData("another");
            group.Header = "test";
            group.Footer = "Group";
            GroupHelper.FillGroupForm(group);
            GroupHelper.SubmitGroupCreation();
            navigator.GroupsPage();
            navigator.Logout();
        }
    }
}
