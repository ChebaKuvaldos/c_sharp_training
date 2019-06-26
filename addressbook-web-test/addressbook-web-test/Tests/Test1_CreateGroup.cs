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
    public class GroupCreationTest : AuthTestBase
    {
        public static IEnumerable<Class2_GroupData> RandomGroupDataProvider()
        {
            List<Class2_GroupData> groups = new List<Class2_GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new Class2_GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<Class2_GroupData> GroupDataFromCsvFile()
        {
            List<Class2_GroupData> groups = new List<Class2_GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new Class2_GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]

                });
            };
            return groups;
        }

        public static IEnumerable<Class2_GroupData> GroupDataFromXmlFile()
        {
            return (List<Class2_GroupData>)
                new XmlSerializer(typeof(List<Class2_GroupData>))
                    .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<Class2_GroupData> GroupDataFromJsonFile()
        {
           return JsonConvert.DeserializeObject<List<Class2_GroupData>>
                (File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void CreateGroup(Class2_GroupData group)
        {
            app.Navigator.GroupsPage();
            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void CreateBadNameGroup()
        {
            app.Navigator.GroupsPage();
            Class2_GroupData group = new Class2_GroupData("Gro'up11");
            group.Header = "Root";
            group.Footer = "Good";

            List<Class2_GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<Class2_GroupData> newGroups = app.Groups.GetGroupList();
           // oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
    }

