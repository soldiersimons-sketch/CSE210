Reference reference = new Reference("Proverbs", 3, 5, 6);

string text =
    "Trust in the Lord with all thine heart and lean not unto thine own understanding. " +
    "In all thy ways acknowledge him, and he shall direct thy paths.";

Scripture scripture = new Scripture(reference, text);

string input = "";

while (input != "quit" && !scripture.IsCompletelyHidden())
{
    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
    Console.WriteLine();
    Console.Write("Press Enter to continue or type 'quit' to finish: ");

    input = Console.ReadLine()?.Trim().ToLower() ?? "";

    if (input != "quit")
    {
        scripture.HideRandomWords(3);
    }
}

Console.Clear();
Console.WriteLine(scripture.GetDisplayText());
Console.WriteLine();
Console.WriteLine("Program finished.");
