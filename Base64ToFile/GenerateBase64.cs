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
            //set console title
            Console.Title = "File to Base64 string";
        chooseDir:
            Console.WriteLine("Input Directory:");
            //set directory path
            string directory = Console.ReadLine().ToString();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(directory);
            Console.ResetColor();
            //checks if path is null and replaces with current directory
            if (directory == "")
            {
                directory = Directory.GetCurrentDirectory();
            }
            //checks path exists
            else if (!Directory.Exists(directory))
            {
                Console.WriteLine("Invalid Directory");
                goto chooseDir;
            }
            //makes sure path ends with separator and adds if needed for consistency
            if (directory.EndsWith(Path.DirectorySeparatorChar))
            { }
            else
            {
                directory = directory + Path.DirectorySeparatorChar;
            }
            //lists all files in the directory
            Console.WriteLine("Choose a file");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var file in
            Directory.EnumerateFiles(directory))
            {
                Console.WriteLine(file);


            }
            Console.ResetColor();
            //choose file to be converted
            string readFile = Console.ReadLine().ToString();
            if(File.Exists(directory + readFile))
            {
                //convert file into a byte array
                byte[] BArray = File.ReadAllBytes(directory + readFile);
                //convert byte array to Base64 string
                string B64String = Convert.ToBase64String(BArray);
                Console.ForegroundColor = ConsoleColor.Red;
                //displays Base64 string
                Console.WriteLine(B64String);
                Console.ResetColor ();
                //choose output file name (it will go in the previously set directory)
                Console.WriteLine("Outfile name:");
                string outfile = Console.ReadLine().ToString();
                if (outfile == "")
                {
                    outfile = readFile + ".txt";


                }
                //write Base64 string to text file
                File.WriteAllText(directory + outfile, B64String);


            }
            else
            {
                Console.WriteLine("No file exists");


            }





            
















        }











    }
}
