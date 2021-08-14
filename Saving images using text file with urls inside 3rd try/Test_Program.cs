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
            string TextFilePath = @"D:\just-urls.txt";
            string textt = File.ReadAllText(@"D:\just-urls.txt");
            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(TextFilePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            using (WebClient client = new WebClient())
            {
                foreach (var item in lines)
                {
                        Span<int> storage = stackalloc int[10];
                        int num = 0;
                        foreach (ref int item1 in storage)
                        {
                            item1 = num++;
                        }
                        foreach (ref readonly var item1 in storage)
                        {
                            client.DownloadFile(item, AppDomain.CurrentDomain.BaseDirectory + $"{item1} " + ".jpg");
                        }
                }
            }
            Console.WriteLine("Program done");
            Console.ReadLine();
        }
    }
}