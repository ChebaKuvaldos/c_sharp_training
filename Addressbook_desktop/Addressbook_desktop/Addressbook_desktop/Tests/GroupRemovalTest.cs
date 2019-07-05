using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_desktop
{
    [TestFixture]
    public class GroupRemovalTest : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData group = oldGroups[0];
            app.Groups.DeleteGroup(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(1);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
