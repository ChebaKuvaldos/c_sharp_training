using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_test
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS) { 
            List<Class2_GroupData> fromUI = app.Groups.GetGroupList();
            List<Class2_GroupData> fromDB = Class2_GroupData.GetAllGroupInfo();
            fromUI.Sort();
            fromDB.Sort();
            Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
