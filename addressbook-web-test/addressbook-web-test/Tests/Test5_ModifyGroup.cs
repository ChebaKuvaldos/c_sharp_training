using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            Class2_GroupData group = new Class2_GroupData("Yozha");
            group.Header = null;
            group.Footer = null;
            if (app.Groups.IsElementPresent(By.XPath("(//input [@name='selected[]'])['1']"))) {  }
            else
            {
                Class2_GroupData ifgroup = new Class2_GroupData("group");
                ifgroup.Header = "for";
                ifgroup.Footer = "meteor";
                app.Groups.Create(ifgroup);
            };
            app.Groups.SelectGroup(1)
                      .ModifySelectedGroup()
                      .FillGroupForm(group)
                      .UpdateGroup();


        }
    }
}
