using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
        private List<Class3_ContactData> contactCache = null;

        public List<Class3_ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<Class3_ContactData>();
                manager.Navigator.HomePage();
                ICollection<IWebElement> list = driver.FindElements(By.Name("entry"));
                foreach (IWebElement item in list)
                {
                    contactCache.Add(new Class3_ContactData(item.FindElement(By.XPath(".//td[3]")).Text,
                    item.FindElement(By.XPath(".//td[2]")).Text));
                }
                return contactCache;
            }
            return new List<Class3_ContactData>(contactCache);
        }

        public Class3_ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.HomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new Class3_ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
            };
        }

        public Class3_ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.HomePage();
            EditContact(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            /*
            string bday = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            
            string birthday = "Birthday " + bday + ". " + bmonth + " " + byear;
            */

            return new Class3_ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
                // Birthday = birthday, чето с birthday не срослось =С
            };

        }

        public Class3_ContactData GetContactInformationFromProperty(int index)
          {
              manager.Navigator.HomePage();
              ContactProperty(index);
            string text = driver.FindElement(By.Id("content")).Text.Trim();
            return new Class3_ContactData(text);
              
           }

        /*
       public int GetNumberOfSearchResult()
       {
           manager.Navigator.HomePage();
           string text = driver.FindElement(By.TagName("label")).Text;
           Match m = new Regex(@"\d+").Match(text);
           return Int32.Parse(m.Value);
       }
*/
        public ContactHelper FillContactData(Class3_ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("bday"), contact.Bday);
            Type(By.Name("bmonth"), contact.Bmonth);
            Type(By.Name("Byear"), contact.Byear);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper AddContactSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactHelper InitAddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper ContactProperty(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public void ContactExist()
        {
            if (IsElementPresent(By.CssSelector("img[alt=\"Edit\"]"))) { }
            else
            {
                Class3_ContactData ifcontact = new Class3_ContactData("Petya", "Dude");
                ifcontact.MobilePhone = "+791111111";
                CreateContact(ifcontact);
            };
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
            EditContact(0)
                        .FillContactData(data)
                        .UpdateContact(); ;
        }
    }
}
