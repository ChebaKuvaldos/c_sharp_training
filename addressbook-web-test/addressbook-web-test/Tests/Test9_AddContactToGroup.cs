using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class Test9_AddContactToGroup : AuthTestBase
    {
        [Test]
        public void AddContactToGroup()
        {
            Class2_GroupData group = Class2_GroupData.GetAllGroupInfo()[0];
            List<Class3_ContactData> oldList = group.GetContacts();
            Class3_ContactData contact = Class3_ContactData.GetAllContactInfo()
                                            .Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<Class3_ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
