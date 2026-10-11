using System;
using System.Diagnostics;
using System.Threading;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Stopwatch timer = Stopwatch.StartNew();
        PerformActivity(timer);
        timer.Stop();
        DisplayEndingMessage();
    }

    protected abstract void PerformActivity(Stopwatch timer);

    protected int SecondsRemaining(Stopwatch timer) =>
        Math.Max(0, (int)Math.Ceiling(_duration - timer.Elapsed.TotalSeconds));

    protected int DurationSeconds => _duration;

    protected bool HasTimeRemaining(Stopwatch timer) => timer.Elapsed.TotalSeconds < _duration;

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            if (int.TryParse(Console.ReadLine(), out int seconds) && seconds > 0 && seconds <= 3600)
            {
                _duration = seconds;
                break;
            }
            Console.WriteLine("Please enter a whole number from 1 to 3600.");
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            Console.Write($"{number} ");
            Thread.Sleep(1000);
            Console.Write(new string('\b', number.ToString().Length + 1));
            Console.Write(new string(' ', number.ToString().Length + 1));
            Console.Write(new string('\b', number.ToString().Length + 1));
        }
    }

    protected void ShowSpinner(int seconds)
    {
        char[] frames = { '|', '/', '-', '\\' };
        int ticks = seconds * 4;
        for (int i = 0; i < ticks; i++)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
}
