public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing", "This activity helps you relax by guiding your breathing.", duration) { }

    public void Run()
    {
        DisplayStartingMessage();
        IncrementLog();  // Log the activity
        
        for (int i = 0; i < _duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            BreathingAnimation(4);  // Realistic animation for breathing in
            Console.WriteLine("Breathe out...");
            BreathingAnimation(4);  // Realistic animation for breathing out
        }
        DisplayEndingMessage();
    }

    private void BreathingAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(new string(' ', i) + "O");
            Thread.Sleep(250 * (i + 1));  // Start fast, slow down
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
