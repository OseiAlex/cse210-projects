using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for user input
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());
        string letter = "";
        string sign = "";

        // Determine letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Add sign (+ or -) to the letter grade, excluding A and F
        if (letter != "A" && letter != "F")
        {
            int lastDigit = percentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Print letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine if the user passed the course
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }
    }
}
