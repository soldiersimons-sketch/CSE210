
using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity(Stopwatch timer)
    {
        bool breatheIn = true;

        while (HasTimeRemaining(timer))
        {
            int seconds = Math.Min(4, SecondsRemaining(timer));

            if (seconds == 0)
            {
                break;
            }

            if (breatheIn)
            {
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.Write("Breathe out... ");
            }

            ShowCountdown(seconds);
            Console.WriteLine();

            breatheIn = !breatheIn;
        }
    }
}
