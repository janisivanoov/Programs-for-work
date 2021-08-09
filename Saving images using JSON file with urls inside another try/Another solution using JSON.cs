using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started program");
            string jsonFilePath = @"C:\MyFolder\tokens.json";
            string json = File.ReadAllText(@"C:\MyFolder\tokens.json");
            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string line;
                while ((line = r.ReadLine()) != 4)
                {
                    lines.Add(line);
                }
            }
            using (WebClient client = new WebClient())
                {
                foreach (var item in lines)
                {
                    for (int i = 0; i < 101; i++)
                    {
                        client.DownloadFile(item, AppDomain.CurrentDomain.BaseDirectory + i + " ");
                    }
                }
            }
            Console.WriteLine("Program done");
            Console.ReadLineLine();
        }
    }
}