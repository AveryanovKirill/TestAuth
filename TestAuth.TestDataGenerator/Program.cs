using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TestAuth.Model;

namespace TestAuth.TestDataGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Использование:");
                Console.WriteLine("generator.exe file <count> <filename> xml");
                return;
            }

            string dataType = args[0];
            int count = int.Parse(args[1]);
            string filename = args[2];
            string format = args[3];

            if (dataType == "file")
            {
                List<FileData> files = GenerateFiles(count);

                if (format == "xml")
                {
                    SaveFilesToXml(files, filename);
                }
            }
        }

        static List<FileData> GenerateFiles(int count)
        {
            List<FileData> files = new List<FileData>();

            for (int i = 0; i < count; i++)
            {
                files.Add(new FileData($"Test file {i}"));
            }

            return files;
        }

        static void SaveFilesToXml(List<FileData> files, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FileData>));

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, files);
            }
        }
    }
}