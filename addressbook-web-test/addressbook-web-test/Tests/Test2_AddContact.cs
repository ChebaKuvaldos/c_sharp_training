using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class AddContact : AuthTestBase
    {
        public static IEnumerable<Class3_ContactData> RandomContactDataProvider()
        {
            List<Class3_ContactData> groups = new List<Class3_ContactData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new Class3_ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(150),
                    MobilePhone = GenerateRandomString(10),
                    HomePhone = GenerateRandomString(10),
                    WorkPhone = GenerateRandomString(10),
                });
            }
            return groups;
        }

        public static IEnumerable<Class3_ContactData> WriteContactsToCsvFile()
        {
            List<Class3_ContactData> contacts = new List<Class3_ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new Class3_ContactData()
                {
                    Firstname = parts[0],
                    Lastname = parts[1],
                    Address = parts[2],
                    MobilePhone = parts[3],
                    Email = parts[4]
                });
            };
            return contacts;
        }

        public static IEnumerable<Class3_ContactData> WriteContactsToXmlFile()
        {
            return (List<Class3_ContactData>)
                new XmlSerializer(typeof(List<Class3_ContactData>))
                    .Deserialize(new StreamReader(@"contact.xml"));
        }

        public static IEnumerable<Class3_ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Class3_ContactData>>
                 (File.ReadAllText(@"contact.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void TheAddContactTest(Class3_ContactData contact)
        {
            List<Class3_ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.CreateContact(contact);
            List<Class3_ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }

        }
}
