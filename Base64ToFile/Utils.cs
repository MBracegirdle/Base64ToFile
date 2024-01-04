using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64ToFile
{
    internal class Utils
    {
        public static void ReadB()
        {
            //set directory
            string directory = workingDir();
            //set file
            string F = getValidInputFile(directory);
            //create empty string
            string str = string.Empty;
            //for each type of text encoding print the first 30 characters as a string
            foreach(var e in Encoding.GetEncodings())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(e.Name+", ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.DisplayName);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("First line: ");
                Console.ResetColor();
                str = File.ReadLines(F, e.GetEncoding()).First();
                //print first 30 characters of byte array as string
                Console.WriteLine(str.Substring(0,Math.Min(str.Length,30)));
            }
            


        }

        public static bool YN(string queryText)
        {
        question:
            Console.WriteLine(queryText);
            ConsoleKey A = Console.ReadKey().Key;
            Console.WriteLine();
            switch (A)
            {
                case ConsoleKey.Y:
                    return true;
                    break;
                case ConsoleKey.N:
                    return false;
                    break;
                default:
                    Console.WriteLine("Invalid response");
                    goto question;
                    break;
            }

        }
        //outputs a valid directory and displays all files (of a specific extension) within
        public static string workingDir(string ext = "*")
        {
        chooseDir:
            Console.WriteLine("Input Directory:");
            string directory = Console.ReadLine().ToString();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(directory);
            Console.ResetColor();
            //sets path to current directory if left blank
            if (directory == "")
            {
                directory = Directory.GetCurrentDirectory();
            }
            //checks directory exists
            else if (!Directory.Exists(directory))
            {
                Console.WriteLine("Invalid Directory");
                goto chooseDir;
            }
            //ensures path ends with separator for consistency
            if (directory.EndsWith(Path.DirectorySeparatorChar) == false)
            {
                directory = directory + Path.DirectorySeparatorChar;
            }

            //lists all .txt files in directory
            Console.WriteLine("Choose a file");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var file in
            Directory.EnumerateFiles(directory, ext))
            {
                Console.WriteLine(file);


            }
            Console.ResetColor();
            return directory;

        }

        public static string getValidInputFile(string P, bool allowPaste = false, string ext = "")
        {

        failOver:
            Console.WriteLine("Which input file do you want to use?");
            //shows additional line if pasting value from clipboard is allowed
            if (allowPaste)
            {
                Console.WriteLine("press enter if you wish to paste value");
            }
            string s = Console.ReadLine().ToString();
            if (s == "")
            {
                //come back to this later - can't get it to work
                goto failOver;
            }
            if (File.Exists(P + s) && s.EndsWith(ext))
            {
                Console.WriteLine(P + s);
                return P + s;
            }
            else
            {

                goto failOver;
            }


        }



        public static string getOutputFile(string Path, string extension = "")
        {
            //adds file extension . to file extension
            if (extension.StartsWith(".") == false && extension.Length > 0)
            {
                extension = "." + extension;
            }
        Reset:
            Console.Write("Output ");
            if (extension.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(extension + " ");
                Console.ResetColor();
            }

            Console.WriteLine("file name:");
            string f = Console.ReadLine();
            //if forced file type add to file name
            if (f.EndsWith(extension) == false)
            {

                //checks and warns if file input has no extension
                if (f.Contains("."))
                {
                    Console.WriteLine(f.Substring(f.IndexOf(".")));


                }
                else
                {

                    if (YN("File has no extension. Continue?") == false)
                    {
                        goto Reset;

                    }
                }
            }
        checkFile:
            if (File.Exists(Path + f))
            {
                //if file already exists will warn and ask if you want to override
                Console.WriteLine("File " + Path + f + " already exists.");
                if (YN("Are you sure you want to overwrite this file?"))
                {
                    return Path + f;
                }
                else
                {
                    goto Reset;
                }


            }
            else if (Directory.Exists(Path))
            {
                //if folder exists but file doesn't
                return Path + f;


            }
            else
            {
                //if folder does not exist set folder or make new folder
                Console.WriteLine("Invalid directory");
            dirFail:
                Console.WriteLine("1. Make directory or 2. choose new directory");
                ConsoleKey k = Console.ReadKey().Key;
                Console.WriteLine();
                switch (k)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //create folder and loop to check for existing file
                        YN("Create folder " + Path + "?");
                        Directory.CreateDirectory(Path);
                        goto checkFile;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //change directory and loop to check for existing file
                        Path = workingDir();
                        goto checkFile;
                        break;
                    default:
                        //loop if invalid char used
                        goto dirFail;
                        break;

                }
            }
        }
        //convert Base64 string to URL safe
        public static string Base64URLSafe(string s)
        {
            return s.Replace("+", "-").Replace("/", "_");

        }
        public static string Base64URLUnsafe(string s)
        {
            return s.Replace("-", "+").Replace("_", "/");


        }





    }
}
