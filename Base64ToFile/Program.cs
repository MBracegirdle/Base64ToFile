// See https://aka.ms/new-console-template for more information
using Base64ToFile;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Web;


internal class Program
{
    private static void Main(string[] args)
    {
        

        Console.WriteLine("1 for Base64 to file, 2 for file to Base64, 3 to parse bytes as text");
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


            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                Console.Clear();
                Utils.ReadB();
                break;

        }

    }



}