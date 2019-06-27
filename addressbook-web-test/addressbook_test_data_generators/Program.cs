using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (dataType == "contact")
            {
                List<Class3_ContactData> contacts = new List<Class3_ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new Class3_ContactData(
                        TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10))
                    {

                        Address = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10)
                    });
                };
                    if (format == "csv")
                    {
                        WriteContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        Console.Out.Write("Unrecognized format " + format);
                    }
                
                writer.Close();
            }

            else if (dataType == "group")
            {

                List<Class2_GroupData> groups = new List<Class2_GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new Class2_GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format" + format);
                }
            }


                writer.Close();
            }

        //Group Methods
        static void WriteGroupsToCsvFile(List<Class2_GroupData> groups, StreamWriter writer)
            {
                foreach (Class2_GroupData group in groups)
                    writer.WriteLine(string.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }

            static void WriteGroupsToXmlFile(List<Class2_GroupData> groups, StreamWriter writer)
            {
            new XmlSerializer(typeof(List<Class2_GroupData>)).
                Serialize(writer, groups);
            }

        static void WriteGroupsToJsonFile(List<Class2_GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, 
                Newtonsoft.Json.Formatting.Indented));
        }

        //Contact Methods
        static void WriteContactsToCsvFile(List<Class3_ContactData> contacts, StreamWriter writer)
        {
            foreach (Class3_ContactData contact in contacts)
                writer.WriteLine(string.Format("${0},${1},${2},${3},${4}",
                contact.Firstname, contact.Lastname, contact.Address, 
                contact.MobilePhone, contact.WorkPhone, contact.HomePhone,
                contact.Email, contact.Email2, contact.Email3));
        }

        static void WriteContactsToXmlFile(List<Class3_ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Class3_ContactData>))
                .Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<Class3_ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, 
                Newtonsoft.Json.Formatting.Indented));
        }

    }
    } 
