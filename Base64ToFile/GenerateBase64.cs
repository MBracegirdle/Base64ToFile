using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64ToFile
{
    internal class GenerateBase64
    {
        public static void ExportB64String()
        {
            Console.Title = "File to Base64 string";
        chooseDir:
            Console.WriteLine("Input Directory:");
            string directory = Console.ReadLine().ToString();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(directory);
            Console.ResetColor();
            if (directory == "")
            {
                directory = Directory.GetCurrentDirectory();
            }
            else if (!Directory.Exists(directory))
            {
                Console.WriteLine("Invalid Directory");
                goto chooseDir;
            }
            if (directory.EndsWith(Path.DirectorySeparatorChar))
            { }
            else
            {
                directory = directory + Path.DirectorySeparatorChar;
            }

            Console.WriteLine("Choose a file");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var file in
            Directory.EnumerateFiles(directory))
            {
                Console.WriteLine(file);


            }
            Console.ResetColor();
            string readFile = Console.ReadLine().ToString();
            if(File.Exists(directory + readFile))
            {
                byte[] BArray = File.ReadAllBytes(directory + readFile);
                string B64String = Convert.ToBase64String(BArray);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(B64String);
                Console.ResetColor ();
                Console.WriteLine("Outfile name:");
                string outfile = Console.ReadLine().ToString();
                if (outfile == "")
                {
                    outfile = readFile + ".txt";


                }

                File.WriteAllText(directory + outfile, B64String);


            }
            else
            {
                Console.WriteLine("No file exists");


            }





            
















        }











    }
}
