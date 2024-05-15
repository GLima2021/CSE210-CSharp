using System;
using System.IO;

namespace MemorizationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Memorization App!");

            string basePath = @"C:\Users\Gabriel Lima\Documents\CSE210-CSharp\BibleHelp\";

            
            string romansFilePath = basePath + "romans_8_28.txt";
            string psalmsFilePath = basePath + "salmo_23.txt";

            
            Scripture romansScripture = LoadScripture(romansFilePath);
            Scripture psalmsScripture = LoadScripture(psalmsFilePath);

            Console.WriteLine($"Loaded scripture: {romansScripture.Reference}");
            Console.WriteLine($"Loaded scripture: {psalmsScripture.Reference}");

            Console.WriteLine("How many words do you want to hide at once?");
            int hideCount;
            while (!int.TryParse(Console.ReadLine(), out hideCount) || hideCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            Console.WriteLine("Press Enter to begin or type 'quit' to exit.");
            string input = Console.ReadLine();

            while (input.ToLower() != "quit" && (!romansScripture.AllWordsHidden() || !psalmsScripture.AllWordsHidden()))
            {
                Console.Clear();

                if (!romansScripture.AllWordsHidden())
                {
                    Console.WriteLine($"Reference: {romansScripture.Reference}");
                    Console.WriteLine(romansScripture.GetVisibleScripture());
                }
                else if (!psalmsScripture.AllWordsHidden())
                {
                    Console.WriteLine($"Reference: {psalmsScripture.Reference}");
                    Console.WriteLine(psalmsScripture.GetVisibleScripture());
                }

                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                input = Console.ReadLine();
                if (input.ToLower() != "quit")
                {
                    if (!romansScripture.AllWordsHidden())
                    {
                        romansScripture.HideRandomWords(hideCount);
                    }
                    else if (!psalmsScripture.AllWordsHidden())
                    {
                        psalmsScripture.HideRandomWords(hideCount);
                    }
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static Scripture LoadScripture(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string reference = lines[0];
            string text = string.Join(" ", lines[1..]); 
            return new Scripture(reference, text);
        }
    }
}
