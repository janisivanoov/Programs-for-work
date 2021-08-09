using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The program started");
            const string f = "just-urls.txt";
            List<string> lines = new List<string>(); 
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            using (WebClient client = new WebClient())
            {
                foreach (string s in lines)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        client.DownloadFile(s, AppDomain.CurrentDomain.BaseDirectory + i + ".jpg");
                    }
                }
            }
            Console.WriteLine("The program work is done");
            Console.ReadLine();
        }
    }
}