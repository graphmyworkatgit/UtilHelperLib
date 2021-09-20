using System;
using UtilHelper.UnitTests.FileHandlerTests;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using UtilHelper.Serialization;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace UtilHelperLib
{
    public class Serializer
    {
        public T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


       //     Log.Logger = new LoggerConfiguration()
       //.Enrich.FromLogContext()
       //.WriteTo.Console()
       //.CreateLogger();

            LastRun l = new LastRun("Bowser", 45, 25);
            Stream stream = File.Open("AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, l);
            stream.Close();

            l = null;
            stream = File.Open("AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();
            l = (LastRun)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(l.ToString());

            l.weight = 50;
            l.height = 5.5;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LastRun));
            var XmlFilePath = @"C:\Users\alpha\source\repos\psDigitalVaultSolution\UtilHelper\bin\Debug\netcoreapp3.1\LastRun.xml";
            using (TextWriter tw = new StreamWriter(XmlFilePath))
            {
                xmlSerializer.Serialize(tw, l);

            }
            l = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(LastRun));

            using (TextReader reader = new StreamReader(XmlFilePath))
            {
                object obj = deserializer.Deserialize(reader);
                l = (LastRun)obj;
                reader.Close();
                Console.WriteLine($"{l.AppName} - {l.weight} - {l.height}");

            }

            List<LastRun> theAnimals = new List<LastRun>()
            {
                new LastRun("ru1",60,30),
                new LastRun("ru2",50,20),
                new LastRun("ru1",40,10)
            };
            var XmlListFilePath = @"C:\Users\alpha\source\repos\psDigitalVaultSolution\UtilHelper\bin\Debug\netcoreapp3.1\ListOfLastRun.xml";
            using (Stream fs = new FileStream(XmlListFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(List<LastRun>));
                xmlSerializer2.Serialize(fs, theAnimals);


            }
            theAnimals = null;

            XmlSerializer xmlSerializer3 = new XmlSerializer(typeof(List<LastRun>));
            using (FileStream fs2 = File.OpenRead(XmlListFilePath))
            {
                theAnimals = (List<LastRun>)xmlSerializer3.Deserialize(fs2);

            }
            foreach (LastRun la in theAnimals)
            {
                Console.WriteLine($"{la.AppName} - {la.weight} - {la.height}");

            }
            TestCsvHelpers t = new TestCsvHelpers();
            t.GetAutomobileFromCsv();


            Console.WriteLine("Hello World!");

        }

        
    }
}
