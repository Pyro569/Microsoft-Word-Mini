using System.IO;
using System;
using System.Text;
using System.Security.AccessControl;


namespace WordMini
{
    class Program
    {
        public static void Main(string[] args)
        {
            // variable for path to save file
            Console.WriteLine("File name? ");
            string fileName = Console.ReadLine();

            //ask spot to save file to
            Console.WriteLine("Location to save file to? Must be in format c:/foldername/ ");
            string filePath = Console.ReadLine();

            // make path for saving file
            string path = @"" + filePath + "" + fileName + ".txt";

            // get what the document is
            Console.WriteLine("Please write your document. ");
            string document = Console.ReadLine();

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(document);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
