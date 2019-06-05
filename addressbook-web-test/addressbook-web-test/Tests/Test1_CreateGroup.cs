using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
        [Test]
        public void CreateGroup()
        {
            app.Navigator.GroupsPage();
            Class2_GroupData group = new Class2_GroupData("Group11");
            group.Header = "Root";
            group.Footer = "Good";

            app.Groups.Create(group);

   


        }
        [Test]
        public void CreateEmptyGroup()
        {
            app.Navigator.GroupsPage();
            Class2_GroupData group = new Class2_GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);


        }
    }
}
