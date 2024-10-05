using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main()
    {
        // Load scriptures from a file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        // Randomly select one scripture
        Random rand = new Random();
        int selectedIndex = rand.Next(scriptures.Count);
        Scripture selectedScripture = scriptures[selectedIndex];

        Console.WriteLine($"Selected Scripture: {selectedScripture.GetReference().GetDisplayText()}\n");

        // Track attempts and time
        int attemptCount = 0;
        DateTime startTime = DateTime.Now;

        // Loop until the scripture is fully hidden
        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");

            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            attemptCount++;
            selectedScripture.HideRandomWords(3); // Hide 3 random words at a time
        }

        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        // Output the result
        Console.WriteLine("All words are hidden. Program ended.");
        Console.WriteLine($"Total attempts: {attemptCount}");
        Console.WriteLine($"Total time taken: {duration.TotalSeconds} seconds");
    }

    // Method to load scriptures from a text file
    public static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        // Read each line from the file and parse it
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            // Book name, chapter, verse(s), and scripture text
            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            string versePart = parts[2];

            // Check for verse range
            int verse, endVerse;
            if (versePart.Contains('-'))
            {
                string[] verseRange = versePart.Split('-');
                verse = int.Parse(verseRange[0]);
                endVerse = int.Parse(verseRange[1]);
            }
            else
            {
                verse = int.Parse(versePart);
                endVerse = verse;
            }

            string text = parts[3];

            // Create Reference and Scripture objects and add to the list
            Reference reference = new Reference(book, chapter, verse, endVerse);
            Scripture scripture = new Scripture(reference, text);
            scriptures.Add(scripture);
        }

        return scriptures;
    }
}
