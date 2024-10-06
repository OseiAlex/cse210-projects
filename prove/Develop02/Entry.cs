using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = EscapeCsv(prompt);
        Response = EscapeCsv(response);
        Date = DateTime.Now.ToShortDateString();
    }

    // Escape any quotes or commas in the text to handle CSV format properly
    private string EscapeCsv(string text)
    {
        if (text.Contains(",") || text.Contains("\""))
        {
            text = "\"" + text.Replace("\"", "\"\"") + "\"";
        }
        return text;
    }

    public override string ToString()
    {
        return $"{Date} - Prompt: {Prompt}\nResponse: {Response}";
    }

    public string ToCsvString()
    {
        return $"{Date},{Prompt},{Response}";
    }

    public static Entry FromCsvString(string csvLine)
    {
        string[] parts = csvLine.Split(','); // Simplified splitting for CSV format
        return new Entry(parts[1], parts[2]) { Date = parts[0] };
    }
}
