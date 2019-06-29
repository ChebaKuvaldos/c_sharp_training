using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_test
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        private List<Class2_GroupData> groupCache = null;

        public List<Class2_GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<Class2_GroupData>();

                manager.Navigator.GroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new Class2_GroupData(element.Text));
                }
                return groupCache;
            }
            return new List<Class2_GroupData>(groupCache);
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(Class2_GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {           
            driver.FindElement(By.XPath("(//input [@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroupId(string id)
        {
            driver.FindElement(By.XPath("(//input [@name='selected[]' and @value = '"+ id +"'])")).Click();
            return this;
        }

        public GroupHelper ModifySelectedGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper DeleteSelectedGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper Create(Class2_GroupData group)
        {
            manager.Navigator.GroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GroupsPage();
            return this;
        }

        public GroupHelper GroupExist()
        {
            if (IsElementPresent((By.XPath("(//input [@name='selected[]'])['1']")))) { }
            else
            {
                Class2_GroupData ifgroup = new Class2_GroupData("group");
                ifgroup.Header = "for";
                ifgroup.Footer = "meteor";
                Create(ifgroup);
            };
            return this;
        }

        public GroupHelper RemoveGroup(int g)
        {
            SelectGroup(g);
            DeleteSelectedGroup();
            return this;
        }

        public GroupHelper RemoveGroupDB(Class2_GroupData groups)
        {
            SelectGroupId(groups.Id);
            DeleteSelectedGroup();
            return this;
        }
        
            public void ModifyGroup(int v, Class2_GroupData newData)
        {
            GroupExist()
            .SelectGroup(v)
            .ModifySelectedGroup()
            .FillGroupForm(newData)
            .UpdateGroup();
        }
    }
}
