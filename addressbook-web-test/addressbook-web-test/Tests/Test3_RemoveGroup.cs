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
    public class Test3_RemoveGroup : GroupTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            app.Navigator.GroupsPage();

            List<Class2_GroupData> oldGroups = Class2_GroupData.GetAllGroupInfo();
            Class2_GroupData toBeRemoved = oldGroups[0];

            app.Groups.GroupExist();
            app.Groups.RemoveGroupDB(toBeRemoved);

          //  app.Groups.GroupExist();
          //  app.Groups.RemoveGroup(0);
            List<Class2_GroupData> newGroups = Class2_GroupData.GetAllGroupInfo();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
