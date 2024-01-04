using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Base64ToFile
{
    internal class GenerateFile
    {
        public static void ExportFile()
        {
            //set command prompt title
            Console.Title = "Base64 string to File";
            //define string txtPath
            string txtPath = "";

            //set working directory
            string directory = Utils.workingDir("*.txt");
            //choose txt file to read Base64 string from
            string txtName = Utils.getValidInputFile(directory, false, ".txt");
            //load Base64 string to program and display it
            string txtBase = File.ReadAllText(txtName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(txtBase);
            Console.ResetColor();
            Console.WriteLine();

            //creates byte array
            byte[] baseConversion = null;
            //convert Base64 string to byte array
            try
            {
                //attempts base64 to byte array coversion
                baseConversion = Convert.FromBase64String(txtBase);



            }
            catch (Exception ex)
            {
                //if failed
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine(txtBase.Length + " characters in Base64 string");
                Console.ResetColor();


                //asks if you want to pad the string to make it an acceptable length
                if (Utils.YN("Pad string? y/n"))
                {

                    string tmpPadding = new string('=', 4 - (txtBase.Length % 4));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Adding " + (4 - (txtBase.Length % 4)) + " placeholder = signs");
                    Console.ResetColor();


                    if (Utils.YN("Put placeholder at end of string? (if not this will be added at the beginning)"))
                    {
                        baseConversion = Convert.FromBase64String(txtBase + tmpPadding);
                    }
                    else
                    {
                        baseConversion = Convert.FromBase64String(tmpPadding+txtBase);
                    }
                    
                    


                }




            }


            //choose output file name
            Console.WriteLine("File Name?");

            string fName = Utils.getOutputFile(directory);
            //write byte array to file

            if(Utils.YN("Use simple writing method?"))
            {
                //using WriteAllBytes
                File.WriteAllBytes(fName, baseConversion);


            }
            else
            {
                //using BinaryWriter

                //set encoding
                Console.WriteLine("Set encoding");
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Write("1. ASCII");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" 2. UTF8");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" 3. Unicode");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" 4. Latin1");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" 5. UTF32");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" 6. UTF7");
                Console.ResetColor();
                Console.WriteLine(" or any other character to use default");
                Encoding E = Encoding.Default;
                ConsoleKey EK = Console.ReadKey().Key;
                Console.WriteLine();
                switch (EK)
                {
                    default:
                        E = Encoding.Default;
                        break;
                    case ConsoleKey.NumPad1:case ConsoleKey.D1:
                        E = Encoding.ASCII; break;
                    case ConsoleKey.NumPad2:case ConsoleKey.D2:
                        E = Encoding.UTF8; break;
                    case ConsoleKey.NumPad3:case ConsoleKey.D3:
                        E = Encoding.Unicode; break;
                    case ConsoleKey.NumPad4:case ConsoleKey.D4:
                        E = Encoding.Latin1; break;
                    case ConsoleKey.NumPad5: case ConsoleKey.D5:
                        E = Encoding.UTF32; break;
                        case ConsoleKey.NumPad6:case ConsoleKey.D6:
                        E = Encoding.UTF7; break;
                }

                using (var BW = File.Open(fName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(BW, E, false))
                    {
                        writer.Write(baseConversion);


                    }
                }
            }




            
        }









    }
}
