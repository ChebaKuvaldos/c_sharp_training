using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_desktop
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData group = new GroupData()
            {
                Name = "FirstDesktopGroup"
            };
        
            app.Groups.CreateGroup(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
