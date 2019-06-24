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
    [TestFixture]
    public class Test8_ContactInformationTest : AuthTestBase
    {
        [Test]
        public void ContactInfoHomeToEdit()
        {
           Class3_ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
           Class3_ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void ContactInfoPropertyToEdit()
        {
            Class3_ContactData fromProperty = app.Contacts.GetContactInformationFromProperty(0);
            Class3_ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromProperty.ContactInfo, fromForm.ContactInfo);

        }
    }
}
