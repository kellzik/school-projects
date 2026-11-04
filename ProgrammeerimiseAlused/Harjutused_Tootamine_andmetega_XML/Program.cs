/*
Harjutused:
1. Loo käsitsi (XDocument-iga) XML-fail raamatud.xml, mis sisaldab vähemalt kahte raamatut. Igal raamatul olgu pealkiri, autor ja aasta element.
2. Kirjuta programm, mis loeb raamatud.xml failist XDocument.Load() abil kõik raamatud ja trükib need konsoolile kujul Autor — Pealkiri (aasta).
3. Loo klass Raamat omadustega Pealkiri, Autor ja Aasta. Serialiseeri List<Raamat> faili raamatud.xml ja seejärel deserialiseeri see kohe tagasi ning trüki tulemus konsoolile. Kontrolli, et failis olev XML näeb välja loetav.
4. Loe raamatud.xml failist andmed XDocument-iga ja kasuta LINQ-i, et leida kõik raamatud, mis on ilmunud pärast 2010. aastat. Trüki tulemus ekraanile.
5. Loo programm, mis küsib kasutajalt kordamööda raamatu pealkirja, autori ja aasta, lisab need loendisse ning serialiseerib lõpuks kogu nimekirja XML-faili. Küsimine lõpeb, kui kasutaja jätab pealkirja tühjaks.
*/

// Harjutus 1

using System.Xml.Linq;

namespace BooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = new XDocument(
                new XElement("raamatud",
                    new XElement("raamat",
                        new XElement("pealkiri", "Tööpäev"),
                        new XElement("autor", "Tõnu Õnnepalu"),
                        new XElement("aasta", 2026)
                    ),
                    new XElement("raamat",
                        new XElement("pealkiri", "Pisuhänd"),
                        new XElement("autor", "Eduard Vilde"),
                        new XElement("aasta", 1885)
                    ),
                    new XElement("raamat",
                        new XElement("pealkiri", "Dopamiinisõltlased"),
                        new XElement("autor", "Anna Lembke"),
                        new XElement("aasta", 2023)
                    )
                )
            );

            doc.Save(@"C:\temp\raamatud.xml");
        }
    }
}


// Harjutus 2

using System;
using System.Xml.Linq;

namespace XmlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"C:\temp\raamatud.xml");

            foreach (XElement raamat in doc.Root.Elements("raamat"))
            {
                string pealkiri = raamat.Element("pealkiri").Value;
                string autor = raamat.Element("autor").Value;
                string aasta = raamat.Element("aasta").Value;
                Console.WriteLine(autor + " - " + pealkiri + " (" + aasta + ")");
            }
        }
    }
}


// Harjutus 3

using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlApp
{
    public class Raamat
    {
        public string Pealkiri { get; set; }
        public string Autor { get; set; }
        public int Aasta { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Raamat> raamatud = new List<Raamat>
            {
                new Raamat { Pealkiri = "Tööpäev", Autor = "Tõnu Õnnepalu", Aasta = 2026 },
                new Raamat { Pealkiri = "Piduhänd", Autor = "Eduard Vilde", Aasta = 1885 }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Raamat>));

            using (StreamWriter writer = new StreamWriter(@"C:\temp\raamatud.xml"))
            {
                serializer.Serialize(writer, raamatud);
            }

            using (StreamReader reader = new StreamReader(@"C:\temp\raamatud.xml"))
            {
                raamatud = (List<Raamat>)serializer.Deserialize(reader);
            }

            foreach (Raamat raamat in raamatud)
            {
                Console.WriteLine(raamat.Autor + " - " + raamat.Pealkiri + " (" + raamat.Aasta + ")");
            }
        }
    }
}


// Harjutus 4

using System;
using System.Xml.Linq;

namespace BooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"C:\temp\raamatud.xml");

            var sortRaamatud = doc.Root.Elements("raamat")
                .Where(raamat => int.Parse(raamat.Element("aasta").Value) > 2010);

            foreach (XElement raamat in sortRaamatud)
            {
                string pealkiri = raamat.Element("pealkiri").Value;
                string autor = raamat.Element("autor").Value;
                string aasta = raamat.Element("aasta").Value;
                Console.WriteLine(autor + " - " + pealkiri + " (" + aasta + ")");
            }
        }
    }
}


// Harjutus 5

using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlBooksApp
{
    public class Raamat
    {
        public string Pealkiri { get; set; }
        public string Autor { get; set; }
        public int Aasta { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Raamat> raamatud = new List<Raamat>();

            while (true)
            {
                Console.Write("Sisesta raamatu pealkiri (tühjaks jätmine lõpetab): ");
                string pealkiri = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(pealkiri))
                {
                    break;
                }

                Console.Write("Sisesta autor: ");
                string autor = Console.ReadLine();

                Console.Write("Sisesta aasta: ");
                int aasta = int.Parse(Console.ReadLine());

                raamatud.Add(new Raamat { Pealkiri = pealkiri, Autor = autor, Aasta = aasta });
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Raamat>));

            using (StreamWriter writer = new StreamWriter(@"C:\temp\raamatud_uus.xml"))
            {
                serializer.Serialize(writer, raamatud);
            }
        }
    }
}