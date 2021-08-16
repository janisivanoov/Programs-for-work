using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace _4th_try_for_JSON
{
    class Program
    {
        /*static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("tokens.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                string line;
                int num = 0;
                using (WebClient client = new WebClient())
                {

                }
                Console.ReadLine();
            }
        }
    }
    public class Item
    {
        public string urls;
    }
        */
        public static Workspace Read(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    string json = file.ReadToEnd();
                    var serializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };
                    //return JsonConvert.DeserializeObject<Workspace>(json, serializerSettings);

                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");

                    return null;
                }
            }
        }
        static void Main(string[] args)
        {
            var data = Read(@"D:\tokens.json");

            Console.WriteLine("Hello World!");
        }
    }
    class Item
    {
        public string url;
    }
}
