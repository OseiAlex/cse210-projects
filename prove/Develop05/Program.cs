public class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity("", "", 0);
        activity.LoadLogFromFile("activityLog.txt");

        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Listing");
            Console.WriteLine("3. Reflecting");
            Console.WriteLine("4. Mindfulness");
            Console.WriteLine("5. Save and Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity(10);
                    breathing.Run();
                    break;
                case "2":
                    ListingActivity listing = new ListingActivity(10);
                    listing.Run();
                    break;
                case "3":
                    ReflectingActivity reflecting = new ReflectingActivity(10);
                    reflecting.Run();
                    break;
                case "4":
                    MindfulnessActivity mindfulness = new MindfulnessActivity(10);
                    mindfulness.Run();
                    break;
                case "5":
                    activity.SaveLogToFile("activityLog.txt");  // Save the log to file before exiting
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
