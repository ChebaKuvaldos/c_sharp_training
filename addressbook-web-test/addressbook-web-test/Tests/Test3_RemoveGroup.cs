using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            if (app.Groups.IsElementPresent((By.XPath("(//input [@name='selected[]'])['1']")))) { }
            else
            {
                Class2_GroupData ifgroup = new Class2_GroupData("group");
                ifgroup.Header = "for";
                ifgroup.Footer = "meteor";
                app.Groups.Create(ifgroup);
            };

            app.Groups.SelectGroup(1)
                      .DeleteSelectedGroup();

        }
    }
}
