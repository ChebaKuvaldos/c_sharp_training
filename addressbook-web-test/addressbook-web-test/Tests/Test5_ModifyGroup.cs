using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test5_ModifyGroup : AuthTestBase
    {
        [Test]
        public void ModifyGroupTest()
        {
            app.Navigator.GroupsPage();
            Class2_GroupData group = new Class2_GroupData("Cosa");
            group.Header = null;
            group.Footer = null;
            app.Groups.SelectGroup(1)
                      .ModifySelectedGroup()
                      .FillGroupForm(group)
                      .UpdateGroup();

        }
    }
}
