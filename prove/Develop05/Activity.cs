public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // To keep track of logs
    protected static Dictionary<string, int> activityLog = new Dictionary<string, int>();

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;

        if (!activityLog.ContainsKey(_name))
        {
            activityLog[_name] = 0;
        }
    }

    // Increment the activity count in the log
    public void IncrementLog()
    {
        activityLog[_name]++;
    }

    // Save log to file
    public void SaveLogToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in activityLog)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
            Console.WriteLine("Log successfully saved to file.");  // Confirmation message
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving log: {ex.Message}");
        }
    }

    // Load log from file
    public void LoadLogFromFile(string fileName)
    {
        try
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(": ");
                        if (parts.Length == 2)
                        {
                            string activityName = parts[0];
                            int count = int.Parse(parts[1]);
                            activityLog[activityName] = count;
                        }
                    }
                }
                Console.WriteLine("Log successfully loaded from file.");  // Confirmation message
            }
            else
            {
                Console.WriteLine("No previous log found. A new log will be created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading log: {ex.Message}");
        }
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity. {_description}");
        Console.WriteLine($"This activity will last for {_duration} seconds.\n");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nYou have completed the {_name} activity. Well done!\n");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
