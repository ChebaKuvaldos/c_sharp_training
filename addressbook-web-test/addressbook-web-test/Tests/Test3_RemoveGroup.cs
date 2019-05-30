using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test3_RemoveGroup : AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            app.Navigator.GroupsPage();
            app.Groups.SelectGroup(1)
                      .DeleteSelectedGroup();
            app.Navigator.HomePage()
                         .Logout();
        }
    }
}
