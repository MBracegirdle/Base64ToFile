using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64ToFile
{
    internal class GenerateFile
    {
        public static void ExportFile() {
            Console.Title = "Base64 string to File";
            string txtPath = "";
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
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var file in
            Directory.EnumerateFiles(directory, "*.txt"))
            {
                Console.WriteLine(file);


            }
            Console.ResetColor();
            string txtName = Console.ReadLine().ToString();
            if (File.Exists(txtName))
            {
                txtPath = txtName;
            }
            else
            {
                txtPath = directory + txtName;

            }

            string txtBase = File.ReadAllText(txtPath);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(txtBase);
            Console.ResetColor();
            Console.WriteLine();

            byte[] baseConversion = Convert.FromBase64String(txtBase);

            Console.WriteLine("File Name?");

            string fName = Console.ReadLine().ToString();
            File.WriteAllBytes(directory + fName, baseConversion);









        }











    }
}
