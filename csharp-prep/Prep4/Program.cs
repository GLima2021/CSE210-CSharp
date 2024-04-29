using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

       
        while (true)
        {
            Console.Write("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number == 0)
                break; 

            numbers.Add(number);
        }

       
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

       
        double average = (double)sum / numbers.Count;

        
        int maxNumber = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > maxNumber)
                maxNumber = num;
        }

        
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + maxNumber);
    }
}
