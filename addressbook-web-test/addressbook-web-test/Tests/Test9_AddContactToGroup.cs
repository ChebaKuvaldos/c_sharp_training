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
    [TestFixture]
    public class Test9_AddContactToGroup : AuthTestBase
    {
        [Test]
        public void AddContactToGroup()
        {
            Class3_ContactData contact;
            app.Contacts.ContactExist();
            app.Groups.GroupExist();

            Class2_GroupData group = Class2_GroupData.GetAllGroupInfo()[0];
            List<Class3_ContactData> oldList = group.GetContacts();

            if (Class2_GroupData.GetAllGroupInfo().Count == oldList.Count)
            {
                contact = new Class3_ContactData("new", "contact");
                app.Contacts.CreateContact(contact);
            }

            contact = Class3_ContactData.GetAllContactInfo()
                                            .Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<Class3_ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void RemoveContactToGroup()
        {
            Class3_ContactData contact;

            app.Contacts.ContactExist();
            app.Groups.GroupExist();
            
            Class2_GroupData group = Class2_GroupData.GetAllGroupInfo()
                                    .Find(x => x.Name.Contains("NewTest"));
            if (group == null)
            {
                group = Class2_GroupData.GetAllGroupInfo()[0];
            }

            List<Class3_ContactData> oldList = group.GetContacts();

            if (group.GetContacts().Count == 0)
            {
                contact = Class3_ContactData.GetAllContactInfo()[0];
                app.Contacts.AddContactToGroup(contact, group);

            }
            else
            {
                contact = oldList[0];
            }

            app.Contacts.RemoveContactFromGroup(contact, group);
            List<Class3_ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
