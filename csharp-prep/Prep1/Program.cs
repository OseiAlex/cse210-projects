using System;

class Program
{
    static void Main(string[] args)
    {
        //Ask user for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        //Ask user for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        //Display user's name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");
    }
}