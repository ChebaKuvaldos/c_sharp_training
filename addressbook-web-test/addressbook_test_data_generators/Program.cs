using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
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
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
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
            else 
            {
                Console.Out.Write("Unrecognized format" + format);        
            }


                writer.Close();
            }

        static void WriteGroupsToCsvFile(List<Class2_GroupData> groups, StreamWriter writer)
            {
                foreach (Class2_GroupData group in groups)
                    writer.WriteLine(string.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }

            static void WriteGroupsToXmlFile(List<Class2_GroupData> groups, StreamWriter writer)
            {
            new XmlSerializer(typeof(List<Class2_GroupData>)).Serialize(writer, groups);
            }
        }
    } 
