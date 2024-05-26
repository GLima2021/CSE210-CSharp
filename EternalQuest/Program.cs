using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestManager questManager = new QuestManager();
            questManager.LoadGoals();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Eternal Quest Program");
                Console.WriteLine("================================");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Add New Goal");
                Console.WriteLine("3. Record your Goal");
                Console.WriteLine("4. View Score of your Goal");
                Console.Write("== Choose an option ==");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        questManager.DisplayGoals();
                        break;
                    case "2":
                        questManager.CreateGoal();
                        break;
                    case "3":
                        questManager.RecordEvent();
                        break;
                    case "4":
                        questManager.DisplayScore();
                        break;
                    case "5":
                        questManager.SaveGoals();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    
    public class QuestManager
    {
        private List<Goal> goals = new List<Goal>();
        private int score = 0;
        private const string saveFilePath = "goals.txt";

        public void CreateGoal()
        {
            Console.WriteLine("Choose the type of goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter the name and description of the goal: Ex: Name - Descriction");
            string description = Console.ReadLine();
            Console.Write("Enter the score of the goal: ");
            int value = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(description, value));
                    break;
                case "2":
                    goals.Add(new EternalGoal(description, value));
                    break;
                case "3":
                    Console.Write("Enter the target count for the checklist goal: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(description, value, targetCount));
                    break;
                default:
                    Console.WriteLine("Invalid option. Goal not created.");
                    break;
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()}");
            }
        }

        public void RecordEvent()
        {
            DisplayGoals();
            Console.Write("Enter the number of the goal to record an event: ");
            int goalNumber = int.Parse(Console.ReadLine()) - 1;

            if (goalNumber >= 0 && goalNumber < goals.Count)
            {
                score += goals[goalNumber].RecordEvent();
                Console.WriteLine("Event recorded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Your current score is: {score}");
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter(saveFilePath))
            {
                writer.WriteLine(score);
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.SaveGoal());
                }
            }
        }

        public void LoadGoals()
        {
            if (File.Exists(saveFilePath))
            {
                using (StreamReader reader = new StreamReader(saveFilePath))
                {
                    score = int.Parse(reader.ReadLine());
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        string type = parts[0];
                        string description = parts[1];
                        int value = int.Parse(parts[2]);

                        switch (type)
                        {
                            case "SimpleGoal":
                                goals.Add(new SimpleGoal(description, value));
                                break;
                            case "EternalGoal":
                                goals.Add(new EternalGoal(description, value));
                                break;
                            case "ChecklistGoal":
                                int currentCount = int.Parse(parts[3]);
                                int targetCount = int.Parse(parts[4]);
                                goals.Add(new ChecklistGoal(description, value, targetCount, currentCount));
                                break;
                        }
                    }
                }
            }
        }
    }

    
    public abstract class Goal
    {
        public string Description { get; private set; }
        public int Value { get; private set; }
        public bool IsCompleted { get; protected set; }

        protected Goal(string description, int value)
        {
            Description = description;
            Value = value;
            IsCompleted = false;
        }

        public abstract int RecordEvent();
        public abstract string DisplayStatus();
        public abstract string SaveGoal();
    }

    
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string description, int value) : base(description, value) { }

        public override int RecordEvent()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                return Value;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            return IsCompleted ? $"[X] {Description}" : $"[ ] {Description}";
        }

        public override string SaveGoal()
        {
            return $"SimpleGoal|{Description}|{Value}|{IsCompleted}";
        }
    }

    
    public class EternalGoal : Goal
    {
        public EternalGoal(string description, int value) : base(description, value) { }

        public override int RecordEvent()
        {
            return Value;
        }

        public override string DisplayStatus()
        {
            return $"[∞] {Description}";
        }

        public override string SaveGoal()
        {
            return $"EternalGoal|{Description}|{Value}";
        }
    }

    
    public class ChecklistGoal : Goal
    {
        private int currentCount;
        private int targetCount;

        public ChecklistGoal(string description, int value, int targetCount, int currentCount = 0)
            : base(description, value)
        {
            this.targetCount = targetCount;
            this.currentCount = currentCount;
        }

        public override int RecordEvent()
        {
            if (!IsCompleted)
            {
                currentCount++;
                if (currentCount >= targetCount)
                {
                    IsCompleted = true;
                    return Value + 500; 
                }
                return Value;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            return IsCompleted
                ? $"[X] {Description} (Completed)"
                : $"[ ] {Description} (Completed {currentCount}/{targetCount} times)";
        }

        public override string SaveGoal()
        {
            return $"ChecklistGoal|{Description}|{Value}|{currentCount}|{targetCount}";
        }
    }
}
