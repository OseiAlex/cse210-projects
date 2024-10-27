using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public int Score => _score;

        public void CreateGoal()
        {
            Console.WriteLine("\nThe types of goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("What type of goal would you like to create?: ");
            
            string choice = Console.ReadLine();
            Goal newGoal = null;

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }
            _goals.Add(newGoal);
        }

        public void ListGoals()
        {
            Console.WriteLine("\nGoals:");
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
            Console.WriteLine($"Total Score: {_score}");
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save goals eg. goals.txt: ");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved successfully to {fileName}");
        }

        public void LoadGoals()
        {
             Console.Write("Enter filename to load goals: ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' not found in the program directory.");
                return;
            }

            _goals.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                _score = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    Goal goal = parts[0] switch
                    {
                        "SimpleGoal" => new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])),
                        "EternalGoal" => new EternalGoal(parts[1], parts[2], int.Parse(parts[3])),
                        "ChecklistGoal" => new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])),
                        _ => null
                    };

                    if (goal != null)
                    {
                        if (parts[0] != "EternalGoal" && parts[^1] == "True") goal.MarkAsCompleted();
                        _goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("\nGoals loaded successfully.");
            ListGoals();
        }

        public void RecordEvent()
        {
            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < _goals.Count)
            {
                int points = _goals[choice].RecordEvent();
                _score += points;
                Console.WriteLine($"Event recorded! You earned {points} points. Total Score: {_score}");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
