using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            
            int magicNumber = random.Next(1, 101);

            int guess;
            int attempts = 0;

            
            do
            {
                
                Console.WriteLine("What is your guess?");
                guess = Convert.ToInt32(Console.ReadLine());
                attempts++;

                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            
            Console.WriteLine($"You made {attempts} guesses.");

            
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgain = Console.ReadLine().ToLower();

            
            if (playAgain == "yes")
            {
                Main(args);
            }
        }
    }
}
