
using System;

// Creativity features:
// 1. Tracks completed activities during the current session.
// 2. Reflection questions can be randomized without repeating
//    until all questions have been shown.
// 3. The Listing Activity supports timed keyboard input,
//    so users cannot continue indefinitely after time expires.

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    breathingCount++;
                    break;

                case "2":
                    new ReflectionActivity().Run();
                    reflectionCount++;
                    break;

                case "3":
                    new ListingActivity().Run();
                    listingCount++;
                    break;

                case "4":
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    Console.WriteLine();
                    Console.WriteLine("Your session summary:");
                    Console.WriteLine($"Breathing activities: {breathingCount}");
                    Console.WriteLine($"Reflection activities: {reflectionCount}");
                    Console.WriteLine($"Listing activities: {listingCount}");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}
