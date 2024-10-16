public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts = new List<string>();  // Track used prompts in session

    public ListingActivity(int duration) : base("Listing", "This activity prompts you to list as many items as you can in response to a random prompt.", duration)
    {
        _prompts = new List<string> { "List things you are grateful for.", "List your strengths.", "List things that make you happy." };
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            _prompts.AddRange(_usedPrompts);  // Refill prompts if all have been used
            _usedPrompts.Clear();
        }

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        _prompts.RemoveAt(index);  // Remove the prompt to avoid reuse in this session
        _usedPrompts.Add(prompt);  // Track the used prompt

        return prompt;
    }

    public void Run()
    {
        DisplayStartingMessage();
        IncrementLog();  // Log the activity
        
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Start listing:");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        List<string> userList = new List<string>();

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                userList.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {userList.Count} items.");
        DisplayEndingMessage();
    }
}
