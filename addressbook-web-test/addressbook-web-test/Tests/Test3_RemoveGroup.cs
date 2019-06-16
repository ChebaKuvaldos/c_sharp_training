using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test3_RemoveGroup : AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            app.Navigator.GroupsPage();

            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.GroupExist();
            app.Groups.RemoveGroup(0);
            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
