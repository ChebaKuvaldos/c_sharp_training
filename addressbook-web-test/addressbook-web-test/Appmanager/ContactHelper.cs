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



        public void ContactExist()
        {
            if (IsElementPresent(By.CssSelector("img[alt=\"Edit\"]"))) { }
            else
            {
                Class3_ContactData ifcontact = new Class3_ContactData("Petya", "Dude");
                ifcontact.Mobile = "+791111111";
                CreateContact(ifcontact);
            };
        }

        public List<Class3_ContactData> GetContactsList()
        {
            List<Class3_ContactData> contacts = new List<Class3_ContactData>();
            manager.Navigator.HomePage();
            ICollection<IWebElement> list = driver.FindElements(By.Name("entry"));
            foreach (IWebElement item in list)
            {
               contacts.Add(new Class3_ContactData(item.FindElement(By.XPath(".//td[3]")).Text, 
                    item.FindElement(By.XPath(".//td[2]")).Text));
            }
            return contacts;
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

        public ContactHelper UpdateContact()
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
            driver.FindElement(By.XPath("(//input [@name='selected[]'])[" + (index + 1) + "]")).Click();
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
        public ContactHelper CreateContact(Class3_ContactData contact)
        {
            InitAddContact();
            FillContactData(contact)
                        .AddContactSubmit();
            manager.Navigator.HomePage();
            return this;
        }
        public void RemoveContact(int v)
        {
            manager.Navigator.HomePage();
            SelectContact(v)
                      .DeleteSelectedContact();
            driver.SwitchTo().Alert().Accept();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector("div.msgbox"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            manager.Navigator.HomePage();

        }
        public void ModifyContact(Class3_ContactData data)
        {
            manager.Navigator.HomePage();
            ContactExist();
            EditContact()
                        .FillContactData(data)
                        .UpdateContact(); ;
        }
    }
}
