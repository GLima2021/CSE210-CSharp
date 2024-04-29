using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            // generete the aleatory number
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int attempts = 0; // counting step

            // Loop 
            while (true)
            {
                // Ask the user a hint
                Console.WriteLine("What is your guess?");
                int guess = Convert.ToInt32(Console.ReadLine());
                attempts++; 

                // See if the hint is higher or less from the magic number
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it in " + attempts + " attempts!");
                    break; 
                }
            }

            // Ask the user if want play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain != "yes")
            {
                break; // get out from the loop if the awnser is NOT
            }
        }
    }
}
