// See https://aka.ms/new-console-template for more information
using Base64ToFile;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("1 for Base64 to file, 2 for file to Base64");
        ConsoleKey k = Console.ReadKey().Key;




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
}