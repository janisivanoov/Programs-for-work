using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
namespace Solution_using_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Console.ReadLine();
        }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("tokens.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    using (WebClient client = new WebClient())
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            client.DownloadFile(item, AppDomain.CurrentDomain.BaseDirectory + i + ".jpg");
                        }
                    }
                }
            }
        }
    }
}
