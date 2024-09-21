using System;

class Program
{
    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt the user for their favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    // Main function that calls all the other functions
    static void Main(string[] args)
    {
        DisplayWelcome();  // Call the welcome function

        string userName = PromptUserName();  // Get the user's name
        int userNumber = PromptUserNumber();  // Get the user's favorite number

        int squaredNumber = SquareNumber(userNumber);  // Square the favorite number

        DisplayResult(userName, squaredNumber);  // Display the result
    }
}
