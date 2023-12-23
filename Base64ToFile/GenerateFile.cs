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
            //set command prompt title
            Console.Title = "Base64 string to File";
            //define string txtPath
            string txtPath = "";
        
            //set working directory
            string directory = Program.workingDir("*.txt");
            //choose txt file to read Base64 string from
            string txtName = Program.getValidInputFile(directory,false,".txt");
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
            catch(Exception ex) 
            {
                //if failed
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine(txtBase.Length+" characters in Base64 string");
                Console.ResetColor();


                //asks if you want to pad the string to make it an acceptable length
                if (Program.YN("Pad string? y/n"))
                {
                    string tmpPadding = new string('=',4-(txtBase.Length %4));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Adding " + (4 - (txtBase.Length % 4)) +" placeholder = signs");
                    Console.ResetColor();
                    baseConversion = Convert.FromBase64String(txtBase + tmpPadding);



                }
                
                

                
            }
            

            //choose output file name
            Console.WriteLine("File Name?");

            string fName = Program.getOutputFile(directory);
            //write byte array to file
            
                File.WriteAllBytes( fName, baseConversion);

            
            
            









        }











    }
}
