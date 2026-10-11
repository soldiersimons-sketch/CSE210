using System;

// Exceeding requirements:
// 1. The Reflection Activity cycles through every reflection question before repeating any.
// 2. The program tracks and displays how many times each activity was completed in this session.
// 3. The Listing Activity ends at the requested time even if the user is still typing.

class Program
{
    static void Main()
    {
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            string? choice = Console.ReadLine();

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
                    Console.WriteLine("\nYour completed activities this session:");
                    Console.WriteLine($"Breathing: {breathingCount}, Reflection: {reflectionCount}, Listing: {listingCount}");
                    Console.WriteLine("Thank you for taking time to be mindful!");
                    return;
                default:
                    Console.WriteLine("Please choose 1, 2, 3, or 4.");
                    break;
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
