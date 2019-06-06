using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void CreateEmptyGroup()
        {
            app.Navigator.GroupsPage();
            Class2_GroupData group = new Class2_GroupData("");
            group.Header = "";
            group.Footer = "";
            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void CreateBadNameGroup()
        {
            app.Navigator.GroupsPage();
            Class2_GroupData group = new Class2_GroupData("Gro'up11");
            group.Header = "Root";
            group.Footer = "Good";

            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        
        }

    }
    }

