using System;

class Program
{
    static void Main(string[] args)
    {
        // Tell the first name
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        // Tell the surname
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();

        // Print the user name correctly
        Console.WriteLine("Your name is " + lastName + ", " + firstName + " " + lastName + ".");


    }
}