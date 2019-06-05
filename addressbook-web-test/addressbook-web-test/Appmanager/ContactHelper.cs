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
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        internal void ContactExist()
        {
            if (IsElementPresent(By.CssSelector("img[alt=\"Edit\"]"))) { }
            else
            {
                CreateContact();
            };
        }

        public ContactHelper FillContactData(Class3_ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("homepage"), contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("-");
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        internal ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper AddContactSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input [@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper DeleteSelectedContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper InitAddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper EditContact()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }
        public ContactHelper CreateContact()
        {
            InitAddContact();
            Class3_ContactData contact = new Class3_ContactData();
            contact.Firstname = "Petya";
            contact.Lastname = "Dude";
            contact.Mobile = "+791111111";
            FillContactData(contact)
                        .AddContactSubmit();
            manager.Navigator.HomePage();
            return this;
        }
    }
}
