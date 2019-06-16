using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test5_ModifyGroup : AuthTestBase
    {
        [Test]
        public void ModifyGroupTest()
        {

            app.Navigator.GroupsPage();
            Class2_GroupData newData = new Class2_GroupData("Yozha");
            newData.Header = null;
            newData.Footer = null;
            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.ModifyGroup(0, newData);
            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
