using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            SecondTask();
        }

        static public void FirstTask() {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("https://habr.com/rss/interesting/");
            XmlElement xRoot = xmlDocument.DocumentElement;
            List<Item> listOfPub = new List<Item>();
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode node in xnode.ChildNodes)
                {

                    if (node.Name == "item")
                    {
                        Item item = new Item();
                        foreach (XmlNode itemNode in node.ChildNodes)
                        {

                            if (itemNode.Name == "title")
                            {
                                item.Title = itemNode.InnerText;
                            }

                            if (itemNode.Name == "link")
                            {
                                item.Link = itemNode.InnerText;
                            }

                            if (itemNode.Name == "description")
                            {
                                item.Description = itemNode.InnerText;
                            }

                            if (itemNode.Name == "pubDate")
                            {
                                item.PubDate = itemNode.InnerText;
                            }
                        }
                        listOfPub.Add(item);
                    }

                }
            }

            for (int i = 0; i < listOfPub.Count; i++)
            {
                Console.WriteLine("Title: ");
                Console.WriteLine(listOfPub[i].Title);
                Console.WriteLine("Link: ");
                Console.WriteLine(listOfPub[i].Link);
                Console.WriteLine("Description: ");
                Console.WriteLine(listOfPub[i].Description);
                Console.WriteLine("Date: ");
                Console.WriteLine(listOfPub[i].PubDate);
                Console.WriteLine();
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        static public void SecondTask() {
            XmlDocument xmlDoc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmlDoc.DocumentElement;
            xmlDoc.AppendChild(root);

            Student student = new Student()
            {
                Id = 1,
                Name = "Aknur",
                Age = 18
            };

            XmlNode userNode = xmlDoc.CreateElement("student");

            //(2) string.Empty makes cleaner code
            XmlElement firstElement = xmlDoc.CreateElement(string.Empty, "Id", string.Empty);
            int studentId = student.Id; 
            XmlText firstText = xmlDoc.CreateTextNode(studentId.ToString());
            firstElement.AppendChild(firstText);
            xmlDoc.AppendChild(firstElement);

            XmlElement secondElement = xmlDoc.CreateElement(string.Empty, "Name", string.Empty);
            XmlText secondText = xmlDoc.CreateTextNode(student.Name);
            secondElement.AppendChild(secondText);
            xmlDoc.AppendChild(secondElement);

            XmlElement thirdElement = xmlDoc.CreateElement(string.Empty, "Age", string.Empty);
            int studentAge = student.Age;
            XmlText thirdText = xmlDoc.CreateTextNode(studentAge.ToString());
            thirdElement.AppendChild(thirdText);
            xmlDoc.AppendChild(thirdElement);


            //XmlElement element4 = doc.CreateElement(string.Empty, "level2", string.Empty);
            //XmlText text2 = doc.CreateTextNode("other text");
            //element4.AppendChild(text2);
            //element2.AppendChild(element4);

            xmlDoc.Save("C:\\Users\\ТажибекА\\source\\repos\\ConsoleApp13\\ConsoleApp13\\xmlfile.xml");

        }  
    }
}
