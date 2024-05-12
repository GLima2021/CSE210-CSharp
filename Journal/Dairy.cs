using System;
using System.Collections.Generic;
using System.IO;

namespace DiaryNamespace
{
    public class DiaryEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }
    }

    public class Diary
    {
        private readonly List<DiaryEntry> _entries = new List<DiaryEntry>();

        public void WriteNewEntry()
        {
            string[] _entryPrompts = {
                "Who was the most interesting person you interacted with today?",
                "What was the best part of your day?",
                "How did you see the hand of the Lord in your life today?",
                "What was the strongest emotion you felt today?",
                "If you could do anything today, what would it be?"
            };

            Random _randomGenerator = new Random();
            string _selectedPrompt = _entryPrompts[_randomGenerator.Next(_entryPrompts.Length)];

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine($"\nDate: {currentDate} | Prompt: {_selectedPrompt}");
            Console.Write("Your response: ");
            string _userResponse = Console.ReadLine();

            DiaryEntry _newEntry = new DiaryEntry
            {
                Prompt = _selectedPrompt,
                Response = _userResponse,
                Date = currentDate
            };

            _entries.Add(_newEntry);
        }

        public void DisplayDiary()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}\n");
            }
        }

        public void SaveDiary(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var entry in _entries)
                    {
                        writer.WriteLine($"Date: {entry.Date}");
                        writer.WriteLine($"Prompt: {entry.Prompt}");
                        writer.WriteLine($"Response: {entry.Response}\n");
                    }
                }
                Console.WriteLine("Diary saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving diary: {ex.Message}");
            }
        }

        public void LoadDiary(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    DiaryEntry currentEntry = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Date:"))
                        {
                            currentEntry = new DiaryEntry();
                            currentEntry.Date = line.Substring(6).Trim();
                        }
                        else if (line.StartsWith("Prompt:"))
                        {
                            if (currentEntry != null)
                            {
                                currentEntry.Prompt = line.Substring(8).Trim();
                            }
                        }
                        else if (line.StartsWith("Response:"))
                        {
                            if (currentEntry != null)
                            {
                                currentEntry.Response = line.Substring(9).Trim();
                                _entries.Add(currentEntry);
                                Console.WriteLine($"Date: {currentEntry.Date} | Prompt: {currentEntry.Prompt} | Response: {currentEntry.Response}");
                                currentEntry = null; 
                            }
                        }
                    }
                }
                Console.WriteLine("Diary loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading diary: {ex.Message}");
            }
        }
    }
}
