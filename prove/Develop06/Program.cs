namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Save goals");
                Console.WriteLine("4. Load goals");
                Console.WriteLine("5. Record an event");
                Console.WriteLine("6. Quit");
                Console.Write("Select a choice from the menu: ");
                
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        goalManager.CreateGoal();
                        break;
                    case "2":
                        goalManager.ListGoals();
                        break;
                    case "3":
                        goalManager.SaveGoals();
                        break;
                    case "4":
                        goalManager.LoadGoals();
                        break;
                    case "5":
                        goalManager.RecordEvent();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
