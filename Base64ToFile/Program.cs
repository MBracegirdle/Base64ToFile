// See https://aka.ms/new-console-template for more information
using Base64ToFile;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;


internal class Program
{
    private static void Main(string[] args)
    {
        

        Console.WriteLine("1 for Base64 to file, 2 for file to Base64");
        ConsoleKey k = Console.ReadKey().Key;
        


        //input process
        switch (k)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Console.Clear();
                GenerateFile.ExportFile();

                break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                Console.Clear();
                GenerateBase64.ExportB64String();
                break;

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
        if (directory.EndsWith(Path.DirectorySeparatorChar)==false)
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

    public static string getValidInputFile(string P, bool allowPaste=false,string ext="")
    {

        failOver:
        Console.WriteLine("Which input file do you want to use?");
        //shows additional line if pasting value from clipboard is allowed
        if (allowPaste )
        {
            Console.WriteLine("press enter if you wish to paste value");
        }
        string s = Console.ReadLine().ToString();
        if(s == "")
        {
            //come back to this later - can't get it to work
            goto failOver;
        }
        if(File.Exists(P+ s)&&s.EndsWith(ext)) 
        {
            return s;
        }
        else
        {

            goto failOver;
        }


    }



    public static string getOutputFile(string P)
    {
        Reset:
        Console.WriteLine("Output file name:");
        string f = Console.ReadLine();
        //checks and warns if file input has no extension
        if(f.Contains(".")) 
        {
            Console.WriteLine(f.Substring(f.IndexOf(".")));
        
        
        }
        else
        {
            
            if(YN("File has no extension. Continue?")==false)
            {
                goto Reset;

            }
        }
        checkFile:
        if(File.Exists(P+ f))
        {
            //if file already exists will warn and ask if you want to override
            Console.WriteLine("File "+P+ f+" already exists.");
            if(YN("Are you sure you want to overwrite this file?"))
            {
                return P + f;
            }
            else
            {
                goto Reset;
            }

            
        }
        else if(Directory.Exists(P))
        {
            //if folder exists but file doesn't
            return P + f;


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
                    YN("Create folder " + P + "?");
                    Directory.CreateDirectory(P);
                    goto checkFile;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    //change directory and loop to check for existing file
                    P = workingDir();
                    goto checkFile;
                    break;
                default:
                    //loop if invalid char used
                    goto dirFail;
                    break;

            }


        }

        
    }

}