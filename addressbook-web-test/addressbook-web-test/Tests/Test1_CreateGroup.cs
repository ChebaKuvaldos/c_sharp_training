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
        public static IEnumerable<Class2_GroupData> RandomGroupDataProvider()
        {
            List<Class2_GroupData> groups = new List<Class2_GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new Class2_GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateGroup(Class2_GroupData group)
        {
            app.Navigator.GroupsPage();
            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
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
           // oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
    }

