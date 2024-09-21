using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        
        while (playAgain.ToLower() == "yes")
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101); // Random number between 1 and 100
            int guess = -1;
            int attempts = 0; // Counter for the number of guesses

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++; // Increment each guess

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
                    Console.WriteLine($"You guessed it in {attempts} attempts!");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
    }
}
