using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    
    public abstract class MindfulnessActivity
    {
        protected int duration; 
        protected abstract string ActivityName { get; }
        protected abstract string ActivityDescription { get; }

        public void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"Starting {ActivityName}");
            Console.WriteLine(ActivityDescription);
            Console.Write("Please enter the duration of the activity in seconds: ");
            duration = int.Parse(Console.ReadLine());
            PrepareToBegin();
            RunActivity();
            EndActivity();
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("Prepare to begin...");
            ShowBallAnimation(5);
        }

        protected abstract void RunActivity();

        protected void EndActivity()
        {
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the {ActivityName} for {duration} seconds.");
            ShowBallAnimation(5);
        }

        protected void ShowBallAnimation(int seconds)
        {
            var frames = new[]
            {
                "o  ",
                " o ",
                "  o",
                "  o",
                " o ",
                "o  "
            };

            var endTime = DateTime.Now.AddSeconds(seconds);
            int counter = seconds;

            while (DateTime.Now < endTime)
            {
                foreach (var frame in frames)
                {
                    Console.Write($"\r{frame} {counter} seconds...");
                    Thread.Sleep(200);
                    if (DateTime.Now >= endTime)
                        break;
                }
                counter--;
            }

            Console.Clear();
        }
    }

    
    public class BreathingActivity : MindfulnessActivity
    {
        protected override string ActivityName => "Breathing Activity";
        protected override string ActivityDescription => 
            "This activity will help you relax by guiding you through slow, deep breathing. Clear your mind and focus on your breathing.";

        protected override void RunActivity()
        {
            int halfDuration = duration / 2;
            for (int i = 0; i < halfDuration; i++)
            {
                Console.WriteLine("Breathe in...");
                ShowBallAnimation(4);
                Console.WriteLine("Breathe out...");
                ShowBallAnimation(4);
            }
        }
    }

    
    public class ReflectionActivity : MindfulnessActivity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        protected override string ActivityName => "Reflection Activity";
        protected override string ActivityDescription =>
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        protected override void RunActivity()
        {
            Random rand = new Random();
            Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
            ShowBallAnimation(5);
            int timePerQuestion = 5; 

            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                ShowBallAnimation(timePerQuestion);
            }
        }
    }

    
    public class ListingActivity : MindfulnessActivity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        protected override string ActivityName => "Listing Activity";
        protected override string ActivityDescription =>
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        protected override void RunActivity()
        {
            Random rand = new Random();
            Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
            ShowBallAnimation(5);

            Console.WriteLine("Start listing items...");
            int count = 0;
            var endTime = DateTime.Now.AddSeconds(duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("Item: ");
                Console.ReadLine();
                count++;
            }

            Console.WriteLine($"You listed {count} items.");
        }
    }

    
    public class VisualizationActivity : MindfulnessActivity
    {
        private static readonly List<string> Scenes = new List<string>
        {
            "Imagine yourself on a peaceful beach, with the sound of waves gently crashing against the shore.",
            "Visualize a serene mountain landscape, with birds singing and a gentle breeze.",
            "Picture yourself in a lush forest, with sunlight filtering through the trees and the scent of pine in the air.",
            "Envision a quiet meadow filled with blooming flowers and the sound of a nearby stream."
        };

        private static readonly List<string> FutureScenarios = new List<string>
        {
            "Imagine achieving one of your biggest goals and how it would feel.",
            "Visualize yourself in a happy, fulfilling relationship, surrounded by love.",
            "Picture a future where you are successful and content in your dream career.",
            "Envision yourself in a state of perfect health and well-being, full of energy and vitality."
        };

        protected override string ActivityName => "Visualization Activity";
        protected override string ActivityDescription =>
            "This activity will guide you through visualizing a peaceful scene or a positive future scenario, helping you relax and find inner peace.";

        protected override void RunActivity()
        {
            Random rand = new Random();
            Console.WriteLine(Scenes[rand.Next(Scenes.Count)]);
            ShowBallAnimation(5);

            Console.WriteLine("Now, visualize the following scenario:");
            Console.WriteLine(FutureScenarios[rand.Next(FutureScenarios.Count)]);
            ShowBallAnimation(duration);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine("This app will guide you through various mindfulness activities to help you relax and reflect.");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Visualization Activity");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        new BreathingActivity().StartActivity();
                        break;
                    case "2":
                        new ReflectionActivity().StartActivity();
                        break;
                    case "3":
                        new ListingActivity().StartActivity();
                        break;
                    case "4":
                        new VisualizationActivity().StartActivity();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using the Mindfulness App. Have a great day!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}
