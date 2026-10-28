
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address campus = new Address("101 College Avenue", "Rexburg", "Idaho", "USA");
        Address garden = new Address("50 Garden Road", "Idaho Falls", "Idaho", "USA");

        List<Event> events = new List<Event>
        {
            new Lectures("Technology and Tomorrow", "A discussion of technology careers.", "November 10, 2026", "6:00 PM", campus, "Dr. Taylor", 125),
            new Reception("Community Networking Night", "Meet local professionals and students.", "November 14, 2026", "7:00 PM", campus, "rsvp@example.com"),
            new Outdoor("Autumn Community Picnic", "A family-friendly picnic in the park.", "November 17, 2026", "12:00 PM", garden, "Cool and partly cloudy")
        };

        foreach (Event item in events)
        {
            Console.WriteLine("STANDARD DETAILS");
            Console.WriteLine(item.GetStandardDetails());

            Console.WriteLine("\nFULL DETAILS");
            Console.WriteLine(item.GetFullDetails());

            Console.WriteLine("\nSHORT DESCRIPTION");
            Console.WriteLine(item.GetShortDescription());

            Console.WriteLine("\n" + new string('-', 45) + "\n");
        }
    }
}
