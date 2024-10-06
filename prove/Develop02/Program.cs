using System;
using System.Collections.Generic;
using System.Timers;
using Timer = System.Timers.Timer;

public class Program
{
    static List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What act of kindness did I do or witness today?",
        "What is something I am grateful for today?",
        "What challenge did I overcome today?",
        "What is something that made me smile today?"
    };

    static Timer reminderTimer;

    public static void Main()
    {
        Journal journal = new Journal();
        string userChoice = "";
        
        // Set up reminder notifications every 60 seconds
        StartReminder();

        while (userChoice != "5")
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        // Stop the reminder timer when the program exits
        reminderTimer.Stop();
    }

    static void WriteNewEntry(Journal journal)
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response);
        journal.AddEntry(newEntry);
        Console.WriteLine("Entry added!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter the filename to save the journal (e.g., journal.csv): ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved!");
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename to load the journal (e.g., journal.csv): ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded!");
    }

    // Starts a simple reminder system that prompts the user to write an entry every 60 seconds
    static void StartReminder()
    {
        reminderTimer = new Timer(60000); // Set timer for 60 seconds
        reminderTimer.Elapsed += (sender, e) => 
        {
            Console.WriteLine("\nReminder: Don't forget to write in your journal!");
        };
        reminderTimer.AutoReset = true;
        reminderTimer.Start();
    }
}

// Creativity Features:
// 1. Added more prompts to the list to provide users with a wider variety of questions to respond to.
// 2. Implemented saving and loading of the journal using a CSV file format with proper handling of commas and quotes.
// 3. Added a simple reminder system using a Timer that prompts the user to write an entry every 60 seconds (this simulates a notification feature).
