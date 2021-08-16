
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Bad_Solution_with_JSON
{
    class Program
    {

        static void Main()
        {
            /* Прочитать файл в строку */
            string textFilePath = @"tokens.json";
            string json = File.ReadAllText(textFilePath); /* file not found */

            try
            {
                string content = File.ReadAllText(textFilePath);
                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("There is a problem with file name");
            }
            finally
            {
                Console.WriteLine("No problems");
            }

            /* Parse JSON array */
            dynamic items = JsonConvert.DeserializeObject(json);


            /* Enumerate array items and save images */
            using (WebClient client = new WebClient())
                foreach (var i in items)
                {

                    client.DownloadFile(i.url.Value, i.index.Value + ".jpg");

                    /*Create folder*/
                    string folderName = @"D:\Folder" + i.collection.Value;
                    string pathString = System.IO.Path.Combine(folderName, "SubFolder");
                    System.IO.Directory.CreateDirectory(pathString);

                    /*Catching exceptions*/
                    try
                    {
                        string content = File.ReadAllText(textFilePath);
                        Console.WriteLine(content);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There is a problem" + ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("No problems");
                    }
                }
            string source1 = @"C:\Users\Катя\source\repos\Another_Solution\Another_Solution\bin\Debug\netcoreapp3.1\5164.jpg";
            string source2 = @"C:\Users\Катя\source\repos\Another_Solution\Another_Solution\bin\Debug\netcoreapp3.1\9999.jpg";
            string source3 = @"C:\Users\Катя\source\repos\Another_Solution\Another_Solution\bin\Debug\netcoreapp3.1\9376.jpg";
            string dest1 = @"D:\Folderboredapeyachtclub\5164.jpg";
            string dest2 = @"D:\Foldersuperyeti\9999.jpg";
            string dest3 = @"D:\Folderboredapeyachtclub\9376.jpg";

            File.Move(source1, dest1);
            File.Move(source2, dest2);
            File.Move(source3, dest3);

            /* pass json file name as argument */
            /* pass destination folder as an argument */
            /* get gid of dynamic type, i.e. define explicit type */
        }
        public static void MoveFiles(string source1, string dest1, string dest2, string dest3, string source2, string source3)
        {
            try
            {
                File.Move(source1, dest1);
                File.Move(source2, dest2);
                File.Move(source3, dest3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The problem is" + ex.Message);
            }
        }
    }

}
