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
   public class loginHelper : HelperBase
    {
        

        public loginHelper (ApplicationManager manager) 
            : base (manager)
        {
        }
        public loginHelper Login(Class1_AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return this;
                }
                Logout();
            }
                Type(By.Name("user"), account.Username);
                Type(By.Name("pass"), account.Password);
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            
            return this;
        }

        public bool IsLoggedIn(Class1_AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("Logout")).FindElement(By.TagName("b")).Text
                == "(" + account.Username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("Logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user"));
            }

        }
    }
}
