using System;

namespace MemorizationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

            Console.WriteLine("Press Enter to begin or type 'quit' to exit.");
            string input = Console.ReadLine();

            while (input.ToLower() != "quit" && !scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine($"Reference: {scripture.Reference}");
                Console.WriteLine(scripture.GetVisibleScripture());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                input = Console.ReadLine();
                if (input.ToLower() != "quit")
                {
                    scripture.HideRandomWord();
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
