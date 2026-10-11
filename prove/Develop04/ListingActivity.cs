
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity(Stopwatch timer)
    {
        string prompt = _prompts[
            Random.Shared.Next(_prompts.Count)
        ];

        Console.WriteLine(
            "List as many responses as you can to the following prompt:"
        );
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        // Pause the activity timer during preparation.
        timer.Stop();

        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        Console.WriteLine("Start listing your items:");
        Console.WriteLine();

        timer.Start();

        int count = 0;

        while (HasTimeRemaining(timer))
        {
            Console.Write("> ");

            string? response = ReadTimedLine(timer);

            if (response == null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} item(s)!");
    }

    // Creativity: Stop accepting input when the timer expires,
    // even when the user has not pressed Enter.
    private string? ReadTimedLine(Stopwatch timer)
    {
        string response = "";

        while (HasTimeRemaining(timer))
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(30);
                continue;
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return response;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (response.Length > 0)
                {
                    response = response[..^1];
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                response += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }

        Console.WriteLine();
        return null;
    }
}

