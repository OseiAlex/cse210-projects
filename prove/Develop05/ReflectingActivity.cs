public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts = new List<string>();  // Track used prompts
    private List<string> _usedQuestions = new List<string>();  // Track used questions

    public ReflectingActivity(int duration) : base("Reflecting", "This activity helps you reflect on personal experiences through thought-provoking questions.", duration)
    {
        _prompts = new List<string> { "Think of a time when you overcame a challenge.", "Recall a moment of joy in your life." };
        _questions = new List<string> { "Why was this experience meaningful to you?", "What did you learn from this experience?" };
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            _prompts.AddRange(_usedPrompts);  // Refill prompts if all used
            _usedPrompts.Clear();
        }

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        _prompts.RemoveAt(index);
        _usedPrompts.Add(prompt);

        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            _questions.AddRange(_usedQuestions);  // Refill questions if all used
            _usedQuestions.Clear();
        }

        Random random = new Random();
        int index = random.Next(_questions.Count);
        string question = _questions[index];
        _questions.RemoveAt(index);
        _usedQuestions.Add(question);

        return question;
    }

    public void Run()
    {
        DisplayStartingMessage();
        IncrementLog();  // Log the activity
        
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Think about it for a moment...");

        ShowSpinner(5);  // Pause for reflection
        
        string question = GetRandomQuestion();
        Console.WriteLine($"Question: {question}");
        Console.WriteLine("Think about your answer...");

        ShowSpinner(5);  // Another pause

        DisplayEndingMessage();
    }
}
