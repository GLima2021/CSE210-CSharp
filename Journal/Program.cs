using System;

namespace DiaryNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Diary diary = new Diary();

            while (true)
            {
                Console.WriteLine("\nMy Journal:");
                Console.WriteLine("1. Write a new moment");
                Console.WriteLine("2. Display the diary");
                Console.WriteLine("3. Save the diary to a file");
                Console.WriteLine("4. Load the diary from a file");
                Console.WriteLine("5. Exit");
                Console.Write("What do you want to do today?: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        diary.WriteNewEntry();
                        break;
                    case "2":
                        diary.DisplayDiary();
                        break;
                    case "3":
                        Console.Write("Enter file name to save: ");
                        string saveFileName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(saveFileName))
                        {
                            diary.SaveDiary(saveFileName);
                        }
                        else
                        {
                            Console.WriteLine("Error: File name cannot be null or empty.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter file name to load: ");
                        string loadFileName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(loadFileName))
                        {
                            diary.LoadDiary(loadFileName);
                        }
                        else
                        {
                            Console.WriteLine("Error: File name cannot be null or empty.");
                        }
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
    }
}
