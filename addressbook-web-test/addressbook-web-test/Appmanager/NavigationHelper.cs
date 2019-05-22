using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace addressbook_web_test
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver,string baseURL) 
            : base(driver)
        {
            this.baseURL = baseURL;
        }
        public void HomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void InitAddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}