using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Creative feature: Every 1,000 points increases the player's level.
    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        int progress = _score % 1000;
        Console.WriteLine($"\nScore: {_score} points | Level: {level} | {progress}/1000 points toward the next level");
    }

    public void Start()
    {
        bool running = true;
        Console.WriteLine("Welcome to Eternal Quest!");
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            int choice = ReadInt("Select a choice from the menu: ", 1, 6);
            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: running = false; break;
            }
        }
        Console.WriteLine("Keep moving forward on your Eternal Quest!");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nTypes of Goals:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        int type = ReadInt("Which type of goal would you like to create? ", 1, 3);
        string name = ReadNonEmpty("What is the name of your goal? ");
        string description = ReadNonEmpty("What is a short description of it? ");
        int points = ReadInt("How many points is this goal worth? ", 0, int.MaxValue);
        Goal goal;
        if (type == 1)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == 2)
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            int target = ReadInt("How many times must this goal be completed? ", 1, int.MaxValue);
            int bonus = ReadInt("What is the bonus for completing the goal? ", 0, int.MaxValue);
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one to get started!");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }
        Console.WriteLine("\nChoose the goal you accomplished:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}{(_goals[i].IsComplete() ? " (Complete)" : "")}");
        int number = ReadInt("Which goal did you accomplish? ", 1, _goals.Count);
        int oldLevel = (_score / 1000) + 1;
        int earned = _goals[number - 1].RecordEvent();
        if (earned == 0)
        {
            Console.WriteLine("That goal is already complete. No additional points were awarded.");
            return;
        }
        // Prevent integer overflow from corrupting the total score.
        _score = earned > int.MaxValue - _score ? int.MaxValue : _score + earned;
        Console.WriteLine($"Congratulations! You earned {earned} points!");
        int newLevel = (_score / 1000) + 1;
        if (newLevel > oldLevel)
            Console.WriteLine($"*** LEVEL UP! You reached Level {newLevel}! ***");
    }

    public void SaveGoals()
    {
        string filename = ReadNonEmpty("What is the filename for the goal file? ");
        try
        {
            using (StreamWriter output = new StreamWriter(filename))
            {
                output.WriteLine(_score);
                foreach (Goal goal in _goals)
                    output.WriteLine(goal.GetStringRepresentation());
            }
            Console.WriteLine($"Goals saved to {filename}.");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException)
        {
            Console.WriteLine($"Could not save goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        string filename = ReadNonEmpty("What is the filename for the goal file? ");
        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore) || loadedScore < 0)
                throw new FormatException("Invalid score in save file.");
            List<Goal> loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split('|');
                if (parts.Length < 5) throw new FormatException($"Invalid goal on line {i + 1}.");
                string name = Goal.Decode(parts[1]);
                string description = Goal.Decode(parts[2]);
                int points = int.Parse(parts[3]);
                if (points < 0) throw new FormatException("Negative goal points are not allowed.");
                Goal goal;
                switch (parts[0])
                {
                    case "SimpleGoal":
                        if (parts.Length != 5) throw new FormatException("Invalid simple goal.");
                        goal = new SimpleGoal(name, description, points, bool.Parse(parts[4]));
                        break;
                    case "EternalGoal":
                        if (parts.Length != 5) throw new FormatException("Invalid eternal goal.");
                        int times = int.Parse(parts[4]);
                        if (times < 0) throw new FormatException("Invalid recorded count.");
                        goal = new EternalGoal(name, description, points, times);
                        break;
                    case "ChecklistGoal":
                        if (parts.Length != 7) throw new FormatException("Invalid checklist goal.");
                        goal = new ChecklistGoal(name, description, points,
                            int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                        break;
                    default:
                        throw new FormatException($"Unknown goal type: {parts[0]}");
                }
                loadedGoals.Add(goal);
            }
            // Only replace current progress after the entire file was read successfully.
            _goals = loadedGoals;
            _score = loadedScore;
            Console.WriteLine($"Loaded {_goals.Count} goals from {filename}.");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException || ex is FormatException || ex is OverflowException)
        {
            Console.WriteLine($"Could not load goals: {ex.Message}");
        }
    }

    private static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(answer)) return answer.Trim();
            Console.WriteLine("Please enter a value.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value;
            Console.WriteLine($"Enter a whole number from {min} to {max}.");
        }
    }
}
