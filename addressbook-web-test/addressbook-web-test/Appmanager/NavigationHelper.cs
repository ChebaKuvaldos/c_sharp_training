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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        public NavigationHelper HomePage()
        {
            if (driver.Url == baseURL)
            {
                return this;
            }
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }
        public NavigationHelper GroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("New")))
                    {
                return this;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }


    }
}