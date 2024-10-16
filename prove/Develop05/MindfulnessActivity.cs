public class MindfulnessActivity : Activity
{
    public MindfulnessActivity(int duration) : base("Mindfulness", "This activity helps you stay grounded in the present moment.", duration) { }

    public void Run()
    {
        DisplayStartingMessage();
        IncrementLog();  // Log the activity
        
        Console.WriteLine("Take a moment to observe your surroundings...");
        ShowSpinner(5);  // Simulate mindfulness moment

        Console.WriteLine("Now, focus on your breathing and thoughts...");
        ShowSpinner(5);  // Another mindful pause

        DisplayEndingMessage();
    }
}
