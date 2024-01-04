using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
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
            //set directory path
            string directory = Utils.workingDir();
            //choose file to be converted
            string readFile = Utils.getValidInputFile(directory);
            //read encoding
            using (var stream = File.OpenRead(readFile))
            {
                using (var reader = new StreamReader(stream))
                {
                    reader.Peek();
                    Console.WriteLine(reader.CurrentEncoding);

                

                }

                
                    string outF = Utils.getOutputFile(directory);
                    File.WriteAllText(outF, Convert.ToBase64String(File.ReadAllBytes(readFile)));
                
                
                

            }
                




            
















        }











    }
}
