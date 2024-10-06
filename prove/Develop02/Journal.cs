using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine();
        }
    }

    // Save the journal as a CSV file
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine(entry.ToCsvString());
            }
        }
    }

    // Load the journal from a CSV file
    public void LoadFromFile(string filename)
    {
        entries.Clear();  // Clear current journal entries
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromCsvString(line);
            entries.Add(entry);
        }
    }
}
