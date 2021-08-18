using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Collections;
using AWSS3;

namespace Another_Solution
{
    class Program
    {
        public class Item
        {
            public string collection { get; set; }
            public int index { get; set; }
            public string url { get; set; }

        }

        static void Main()
        {


            /*For void WriteToFile*/
            log(@"D:\Folder", "TestFile", "Here suppose to be a message");


            /*Reading*/
            String line;
            try
            {
                StreamReader sr = new StreamReader(@"D:\Folder\TestFile.txt");
                line = sr.ReadLine(); /*reading first line*/
                while (line != null) /*read till line didnt end*/
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine(); /*reading next line*/
                }
                sr.Close(); /*closing*/
                Console.ReadLine();
            }
            /*catching exceptions*/
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadLine();



            // Interface to S3(example)

            /*
            Stream st = File.Open(@"D:\Folder\boredapeyachtclub\5164.jpg",FileMode.Open);
            string myBucketName = "punks-dev"; //your s3 bucket name goes here
            string s3DirectoryName = "boredapeyachtclub";
            string s3FileName = "5164.JPG";
            bool a;
            AmazonUploader myUploader = new AmazonUploader();
            a = myUploader.transferFile(st, myBucketName, s3DirectoryName, s3FileName);
            if (a == true)
            {
                Console.WriteLine("successfully uploaded");

            }
            else
                Console.WriteLine("Error");
            /*

            /*Catching exceptions with file*/
            string json = null;
            string textFilePath = @"tokens.json";
            try
            {
                json = File.ReadAllText(textFilePath); /* file not found */
                Console.WriteLine(json);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("There is a problem with file name " + ex.Message);
                Environment.Exit(1);
            }

            /* Parse JSON array */
            /* dynamic items = JsonConvert.DeserializeObject(json); */

            Item[] items = null;
    
                items = JsonConvert.DeserializeObject<Item[]>(json);
            
            /* Enumerate array items and save images */
            using (WebClient client = new WebClient())
                foreach (var i in items)
                {

                    /* Create folder if needed */
                    string folderName = @"D:\Folder\" + i.collection + @"\";

                    /*S3*/
                    Stream st = File.Open(@"D:\Folder\" + i.collection + @"\" + i.index + ".jpg", FileMode.Open);
                    string myBucketName = "punks-dev"; //s3 bucket name 
                    string s3DirectoryName = i.collection;
                    string s3FileName = i.index + ".jpg";
                    bool a;
                    AmazonUploader myUploader = new AmazonUploader();
                    a = myUploader.transferFile(st, myBucketName, s3DirectoryName, s3FileName);
                    if (a == true)
                    {
                        Console.WriteLine("Successfully uploaded");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                    /*Catching exception while creating folder*/
                    if (!Directory.Exists(folderName))
                    {

                        try
                        {
                            System.IO.Directory.CreateDirectory(folderName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Cannot create folder. Exception " + ex.Message);
                        }
                    }

                    /*Catching exceptions on download file*/
                    try { 
                    client.DownloadFile(i.url, folderName + i.index + ".jpg");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Cannot save image. Exception " + ex.Message);
                    }
                }

           
        }
        static void log(string directory, string name, string message)
        {
            string filename = String.Format("{0:YYYYMMDDhhmmssfff}__{1}", DateTime.Now, name);
            string path = Path.Combine(directory, filename);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("This is just a test");
            }
        }
    }
}

